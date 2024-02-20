using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    void Start()
    {
        // Make the cursor visible and unlocked on the start screen
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadPacManWorld()
    {
        SceneManager.LoadScene("PacManWorld");
        // Optionally, hide the cursor and lock it when the game starts
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
