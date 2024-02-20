using UnityEngine;

public class SimpleController : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;
    [SerializeField]
    private Animator animator;

    [Header("Movement")]
    [SerializeField]
    private float playerSpeed = 7.0f;
    [SerializeField]
    private float jumpHeight = 1.5f;
    [SerializeField]
    private float gravityValue = -9.81f;

    [Header("Camera Control")]
    [SerializeField]
    private float rotationSpeed = 5.0f;

    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Movement
        Vector3 move = GetInputDirection();
        controller.Move(move * Time.deltaTime * playerSpeed);
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        animator.SetFloat("Forward", move.magnitude);
        animator.SetBool("IsGrounded", groundedPlayer);

        // Jumping
        HandleJumping();

        // Camera Rotation
        HandleCameraRotation();

        // Sliding
        HandleSliding();
    }

    private Vector3 GetInputDirection()
    {
        Vector3 cameraRight = Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up).normalized;
        Vector3 cameraForward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up).normalized;
        return Input.GetAxis("Horizontal") * cameraRight + Input.GetAxis("Vertical") * cameraForward;
    }

    private void HandleJumping()
    {
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void HandleCameraRotation()
    {
        float horizontalRotation = Input.GetAxis("Mouse X") * rotationSpeed;
        transform.Rotate(0, horizontalRotation, 0);
    }

    private void HandleSliding()
    {
        bool isSliding = Input.GetKey(KeyCode.LeftShift) && groundedPlayer;
        animator.SetBool("Sliding", isSliding);
    }
}
