using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStats : MonoBehaviour


{
    private int numPelletsCollected = 0;
    public TextMeshProUGUI countText;
    // Use this for initialization
    void Start()
    {
        countText.text = "Score = " + numPelletsCollected.ToString();
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
            countText.text = "Score = " + numPelletsCollected.ToString();
        }
    }
}

