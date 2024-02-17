using UnityEngine;
using System.Collections;
using TMPro;

public class PacMan : MonoBehaviour
{
    public HUDController hudController; // Reference to the HUDController script
    public float megaChompDuration = 5f;
    public float energyDecreaseOnBadFood = 5f;
    private bool isMegaChompActive = false;
    private int score = 0;
    private float energy = 100f; // Start with 100% energy

    void Start()
    {
        // Initialize HUD
        hudController.UpdateScore(score);
        hudController.UpdateHealth(energy);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check for food items
        if (other.CompareTag("Food"))
        {
            // Increase score
            score += 10; // Example score value for food
            hudController.UpdateScore(score);

            // Optionally increase energy
            energy += 10; // Example energy increase
            energy = Mathf.Clamp(energy, 0, 100); // Keep energy between 0 and 100
            hudController.UpdateHealth(energy);

            Destroy(other.gameObject);
        }
        else if (other.CompareTag("BadPellet"))
        {
            if (!isMegaChompActive)
            {
                // Decrease energy
                energy -= energyDecreaseOnBadFood;
                hudController.UpdateHealth(energy);

                if (energy <= 0)
                {
                    // Handle Pac-Man death
                }
            }
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("MegaChompPellet"))
        {
            ActivateMegaChomp();
            Destroy(other.gameObject);
        }
    }

    private void ActivateMegaChomp()
    {
        if (!isMegaChompActive)
        {
            StartCoroutine(MegaChompRoutine());
        }
    }

    private IEnumerator MegaChompRoutine()
    {
        isMegaChompActive = true;
        // Increase Pac-Man's speed or make him invincible

        // Reduce energy for using Mega-Chomp
        energy -= 20; // Example energy decrease
        hudController.UpdateHealth(energy);

        yield return new WaitForSeconds(megaChompDuration);

        // Reset Pac-Man's speed or invincibility
        isMegaChompActive = false;
    }
}

