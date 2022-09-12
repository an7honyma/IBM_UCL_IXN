using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/*
REFERENCES:
Pause Menu in Unity (Youtube/Brackeys):
https://www.youtube.com/watch?v=JivuXdrIHK0

*/

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenuInterface;
    public GameObject timer;
    public AudioSource buttonSelectedSFX;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Play button sound if hotkey is pressed:
            buttonSelectedSFX.volume = VolumeManager.sfxVolume;
            buttonSelectedSFX.Play();
            // If game is paused:
            if (isPaused)
            {
                ResumeGame();
            }
            // if game is unpaused:
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        // Close pause menu interface:
        pauseMenuInterface.SetActive(false);
        // Enable/resume game progression:
        Time.timeScale = 1f;
        // Toggle Boolean flag:
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuInterface.SetActive(true);
        // Halt game progression:
        Time.timeScale = 0f;
        // Toggle Boolean flag:
        isPaused = true;
    }

    public void LoadMainMenu()
    {
        // Open pause menu interface:
        isPaused = false;
        // Find and destroy timer. Timer will be automatically reloaded and reset on first level if player decides to replay:
        timer = GameObject.FindWithTag("Timer");
        Destroy(timer);
        // Reset game progression:
        Time.timeScale = 1f;
        StartCoroutine(BackToMainMenu());
    }

    IEnumerator BackToMainMenu()
    {
        // Delay for 0.5 seconds:
        yield return new WaitForSecondsRealtime((float)0.5);
        SceneManager.LoadScene("MainMenuScene");
    }
}
