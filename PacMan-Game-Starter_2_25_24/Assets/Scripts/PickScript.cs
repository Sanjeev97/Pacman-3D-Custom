using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))] // Ensure there's an AudioSource component
public class PickScript : MonoBehaviour
{
    public float destroyDelay = 0.2f; // Customizable delay before destruction
    private AudioSource myAudio; // Reference to the AudioSource component

    void Start()
    {
        // Get the AudioSource component attached to the game object
        myAudio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("PacMan"))
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
    }

    private IEnumerator PlayAndDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
