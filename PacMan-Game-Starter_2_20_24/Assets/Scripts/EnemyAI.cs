using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement; // Required for loading scenes

public class GhostAI : MonoBehaviour
{
    public Transform pacManTransform; // Assign in the inspector
    public Transform blinkyTransform; // Assign for Inky's behavior
    public NavMeshAgent agent;
    public enum GhostType { Blinky, Pinky, Inky, Clyde };
    public GhostType ghostType;

    private void Start()
    {
        if (agent == null) agent = GetComponent<NavMeshAgent>();
    }

    private Vector3 GetTargetPosition()
    {
        switch (ghostType)
        {
            case GhostType.Blinky:
                return pacManTransform.position;
            case GhostType.Pinky:
                return pacManTransform.position + pacManTransform.forward * 4;
            case GhostType.Inky:
                // Inky uses both Pac-Man's position and Blinky's position to decide his target
                Vector3 blinkyToPacMan = pacManTransform.position - blinkyTransform.position;
                Vector3 targetPosition = pacManTransform.position + blinkyToPacMan * 0.5f; // Example calculation
                return targetPosition;
            case GhostType.Clyde:
                return Vector3.Distance(transform.position, pacManTransform.position) < 10f ? new Vector3(-10, 0, -10) : pacManTransform.position;
            default:
                return pacManTransform.position;
        }
    }

    void Update()
    {
        agent.SetDestination(GetTargetPosition());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PacMan"))
        {
            SceneManager.LoadScene("GameOver"); // Ensure the GameOver scene is added to your build settings
        }
    }
}
