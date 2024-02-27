using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    void Start()
    {
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadUIScene()
    {
        
        SceneManager.LoadScene("UI");
    }

    public void QuitGame()
    {
      
        Application.Quit();

      
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
