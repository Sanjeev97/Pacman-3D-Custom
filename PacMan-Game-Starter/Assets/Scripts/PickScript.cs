using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Renderer[] allRenderers = gameObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer c in allRenderers) c.enabled = false;
            Collider[] allColliders = gameObject.GetComponentsInChildren<Collider>();
            foreach (Collider c in allColliders) c.enabled = false;
            //StartCoroutine(PlayAndDestroy(myaudio.clip.length));
            StartCoroutine(PlayAndDestroy());

        }
    }

    private IEnumerator PlayAndDestroy()
    {
        //myaudio.Play();
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
