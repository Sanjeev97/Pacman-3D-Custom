using System.Collections;
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

    public float destroyDelay = 0.2f; // Customizable delay before destruction
    private AudioSource myAudio; // Reference to the AudioSource component

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
    {   bool mc = GameObject.Find("Pac-man").GetComponent<GameStats>().megaChomp;
        if(mc == false)
        {
            agent.SetDestination(GetTargetPosition());
        }
        else
        {
            agent.SetDestination(-pacManTransform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PacMan"))
        {

            if (other.GetComponent<GameStats>().megaChomp == true)
            {
                // Disable all renderers and colliders
                Renderer[] allRenderers = GetComponentsInChildren<Renderer>();
                foreach (Renderer renderer in allRenderers) renderer.enabled = false;
                Collider[] allColliders = GetComponentsInChildren<Collider>();
                foreach (Collider collider in allColliders) collider.enabled = false;

                // Play audio if available
                if (myAudio && myAudio.clip)
                {
                    myAudio.Play();
                    StartCoroutine(PlayAndDestroy(myAudio.clip.length)); // Wait for audio to finish
                }
                else
                {
                    StartCoroutine(PlayAndDestroy(destroyDelay)); // Use default delay if no audio
                }
            }
            else 
            { 
                SceneManager.LoadScene("GameOver"); // Ensure the GameOver scene is added to your build settings
            }
        }

        
    }

    private IEnumerator PlayAndDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
