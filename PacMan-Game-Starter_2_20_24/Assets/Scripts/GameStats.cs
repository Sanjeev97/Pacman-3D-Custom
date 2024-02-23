using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStats : MonoBehaviour


{
    private int numPelletsCollected = 0;
    public int health = 100;

    public bool megaChomp;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI healthText;
    public Material myMegaMaterial;
    public GameObject myPacMan;

    private AudioSource[] myAudios; // Reference to the AudioSource component

    // Use this for initialization
    void Start()
    {
        megaChomp = false;
        myPacMan = this.transform.gameObject;
        countText.text = "Score : " + numPelletsCollected.ToString();
        healthText.text = "Health : " + health.ToString() + "%";

        // Get the AudioSource component attached to the game object
        myAudios = GetComponents<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            numPelletsCollected += 1;
            countText.text = "Score : " + numPelletsCollected.ToString();
        }

        if (other.gameObject.CompareTag("BadPickup"))
        {
            health -= 5;
            healthText.text = "Health : " + health.ToString() + "%";
        }

        if(other.gameObject.CompareTag("MegaChompPellet"))
        {
            megaChomp = true;
            myAudios[0].Stop();
            myAudios[1].Play();
            myPacMan.transform.localScale = new Vector3(2, 2, 2);
            StartCoroutine(ReturnBackToNormal(10));
            //myPacMan.GetComponent<Renderer>().material = myMegaMaterial;
        }
    }

    private IEnumerator ReturnBackToNormal(float delay)
    {
        yield return new WaitForSeconds(delay);
        myPacMan.transform.localScale = new Vector3(1, 1, 1);
        megaChomp = false;
        myAudios[1].Stop();
        myAudios[0].Play();

    }
}

