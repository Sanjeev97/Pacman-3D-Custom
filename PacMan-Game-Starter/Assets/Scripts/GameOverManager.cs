using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    // This function could be called automatically when the scene starts
    void Start()
    {
        // Ensure the cursor is visible and not locked
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // This function would be called by your End button's OnClick event
    public void LoadUIScene()
    {
        SceneManager.LoadScene("UI");
    }

    // Additional functions for any other buttons or actions on your Game Over screen
}

