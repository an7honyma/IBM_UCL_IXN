using UnityEngine;

public class OpeningScreen : MonoBehaviour
{
    public GameObject levelOpeningScreen;
    
    void Update()
    {
        // If opening screen panel is open:
        if (levelOpeningScreen.activeSelf)
        {
            // Pause game progression:
            Time.timeScale = 0f;
        }
    }

    public void ResumeTimer()
    {
        // Resume game progression when level opening screen is closed:
        Time.timeScale = 1f;
    }
}
