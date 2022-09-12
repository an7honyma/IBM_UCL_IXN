using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/*
REFERENCES:
Main Menu in Unity (Youtube/Brackeys):
https://www.youtube.com/watch?v=zc8ac_qUXQY

*/

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        StartCoroutine(LoadGame());
    }

    // Used for stand-alone application, instead of web-hosted game:
    public void QuitGame()
    {
        StartCoroutine(ExitApplication());
    }

    IEnumerator LoadGame()
    {
        // Delay for 0.5 seconds:
        yield return new WaitForSecondsRealtime((float)0.5);
        // Load first game level scene:
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator ExitApplication()
    {
        // Delay for 0.5 seconds:
        yield return new WaitForSecondsRealtime((float)0.5);
        // Close the application entirely:
        Application.Quit();
    }
}
