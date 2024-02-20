using UnityEngine;
using UnityEngine.SceneManagement;

public class GameConditions : MonoBehaviour
{
    public float health = 100f; // Start health
    public float gameTimer = 120f; // Length of the game in seconds (e.g., 2 minutes)

    private void Update()
    {
        // Assuming health and timer are decremented elsewhere in your code:
        // If health hits zero or timer runs out, load the GameOver scene.
        if (health <= 0f || gameTimer <= 0f)
        {
            LoadGameOverScene();
        }

        // Decrement the timer
        if (gameTimer > 0)
        {
            gameTimer -= Time.deltaTime;
        }
    }

    void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}

