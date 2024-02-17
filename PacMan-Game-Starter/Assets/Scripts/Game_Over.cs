using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void LoadUI()
    {
        // This will load your main UI scene.
        SceneManager.LoadScene("UI");
    }

    public void QuitGame()
    {
        // Quit the game. This will close the application.
        // If running in the editor, it will stop play mode.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
