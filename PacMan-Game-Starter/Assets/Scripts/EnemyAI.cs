using UnityEngine;
using UnityEngine.AI;

public class GhostAI : MonoBehaviour
{
    public Transform pacManTransform; // Assign in the inspector
    public NavMeshAgent agent;
    public enum GhostType { Blinky, Pinky, Inky, Clyde };
    public GhostType ghostType;

    private Vector3 GetTargetPosition()
    {
        switch (ghostType)
        {
            case GhostType.Blinky:
                return pacManTransform.position;
            case GhostType.Pinky:
                // Example: Target 4 units in front of Pac-Man's current direction
                return pacManTransform.position + pacManTransform.forward * 4;
            case GhostType.Inky:
                // Implement Inky's complex behavior here
                return pacManTransform.position; // Placeholder
            case GhostType.Clyde:
                // Example: If Clyde is close to Pac-Man, target a corner of the map instead
                return Vector3.Distance(transform.position, pacManTransform.position) < 10f ? new Vector3(-10, 0, -10) : pacManTransform.position;
            default:
                return pacManTransform.position;
        }
    }

    void Update()
    {
        agent.SetDestination(GetTargetPosition());
    }
}
