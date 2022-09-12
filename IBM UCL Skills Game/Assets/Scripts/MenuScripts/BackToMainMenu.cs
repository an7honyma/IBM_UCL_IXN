using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BackToMainMenu : MonoBehaviour
{
    public void ReturnToMainMenu ()
    {
        // Return to main menu scene after winning/losing the game:
        StartCoroutine(LoadMainMenu());
    }

    IEnumerator LoadMainMenu()
    {
        // Delay for 0.5 seconds:
        yield return new WaitForSecondsRealtime((float)0.5);
        // Load main menu scene:
        SceneManager.LoadScene("MainMenuScene");
    }
}