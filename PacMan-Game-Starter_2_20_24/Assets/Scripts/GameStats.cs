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

    // Use this for initialization
    void Start()
    {
        megaChomp = false;
        myPacMan = this.transform.gameObject;
        countText.text = "Score : " + numPelletsCollected.ToString();
        healthText.text = "Health : " + health.ToString() + "%";

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
            myPacMan.transform.localScale = new Vector3(3, 3, 3);
            //myPacMan.GetComponent<Renderer>().material = myMegaMaterial;
        }
    }
}

