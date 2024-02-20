using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour
{
    public Text timerText; // Assign this in the inspector
    public float totalTime = 120f; // Total time in seconds (2 minutes)

    private void Start()
    {
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        while (totalTime > 0)
        {
            totalTime -= Time.deltaTime;
            UpdateTimerDisplay();
            yield return null;
        }

        // Optional: Add any actions you want to occur when the timer reaches 0
        TimerEnded();
    }

    void UpdateTimerDisplay()
    {
        // Convert the remaining time into minutes and seconds format
        int minutes = Mathf.FloorToInt(totalTime / 60);
        int seconds = Mathf.FloorToInt(totalTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TimerEnded()
    {
        // Actions to take when the timer ends, e.g., end the game
        Debug.Log("Time's up!");
    }
}
