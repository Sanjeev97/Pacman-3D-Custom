using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStats : MonoBehaviour


{
    private int numPelletsCollected = 0;
    private int health = 100;

    public TextMeshProUGUI countText;
    public TextMeshProUGUI healthText;

    // Use this for initialization
    void Start()
    {
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
    }
}

