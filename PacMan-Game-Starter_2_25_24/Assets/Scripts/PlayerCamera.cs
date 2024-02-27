using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform playerBody; // Assign your player's body transform here in the inspector.
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private bool invertYAxis = false; // Option to invert the Y axis for vertical mouse movement.
    [SerializeField] private float rotationSmoothTime = 0.1f; // Time for smoothing the rotation.
    private float xRotation = 0f;
    private Vector3 rotationSmoothVelocity;
    private Vector3 currentRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen and hide it.
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Apply inversion based on the invertYAxis flag.
        xRotation += (invertYAxis ? mouseY : -mouseY);
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp vertical rotation to prevent flipping.

        // Calculate the smooth rotation.
        Vector3 targetRotation = new Vector3(xRotation, playerBody.eulerAngles.y + mouseX, 0f);
        currentRotation = Vector3.SmoothDamp(currentRotation, targetRotation, ref rotationSmoothVelocity, rotationSmoothTime);

        // Apply the rotation to the camera and player body.
        transform.localRotation = Quaternion.Euler(currentRotation.x, currentRotation.y, 0f);
        playerBody.rotation = Quaternion.Euler(0f, currentRotation.y, 0f);
    }
}
