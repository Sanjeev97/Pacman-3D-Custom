using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel; // Assign the pause panel in the inspector
    public VideoPlayer videoPlayer; // Assign the VideoPlayer in the inspector

    // Added to track the pause state
    private bool isPaused = false;

    private void Update()
    {
        // Check for pause key press or button click
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused; // Toggle the pause state
        pausePanel.SetActive(isPaused);

        if (isPaused)
        {
            Time.timeScale = 0f; // Pause the game
            videoPlayer.Play(); // Play the video
            Cursor.visible = true; // Make sure the cursor is visible
            Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        }
        else
        {
            Time.timeScale = 1f; // Resume the game
            videoPlayer.Stop(); // Stop the video
            Cursor.visible = false; // Optional: Hide the cursor when unpausing
            Cursor.lockState = CursorLockMode.Locked; // Optional: Lock the cursor when unpausing
        }
    }

    // Method to call when the 'Return' button is clicked
    public void ReturnToGame()
    {
        if (isPaused)
        {
            TogglePause(); // Resume the game and close the pause panel
        }
    }

    // Method to call when the 'End' button is clicked
    public void EndGameAndLoadUI()
    {
        if (isPaused)
        {
            Time.timeScale = 1f; // Ensure the game's time is running normally
            SceneManager.LoadScene("UI"); // Load the UI scene
        }
    }
}

