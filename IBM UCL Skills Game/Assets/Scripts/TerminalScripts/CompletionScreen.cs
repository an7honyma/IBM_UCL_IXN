using UnityEngine;

public class CompletionScreen : MonoBehaviour
{
    public GameObject completionScreen;
    public GameObject terminal;
    public GameObject player;
    private bool completed = false;

    public void ExitCompletionScreen()
    {
        // Close the completion screen:
        completionScreen.SetActive(false);
        terminal.GetComponent<CheckPlayerRange>().isInteracting = false;
        // Resume game progression:
        Time.timeScale = 1f;
    }

    void Update()
    {
        // Find player's avatar game object:
        player = GameObject.FindWithTag("Player");

        if (completionScreen.activeSelf)
        {
            // Disable player movement when completion screen is active:
            player.GetComponent<PlayerMovement>().enabled = false;
            completed = true;
            // Pause game progression:
            Time.timeScale = 0f;
        }

        if (completed && !completionScreen.activeSelf)
        {
            // Enable player movement when player closes the completion screen:
            player.GetComponent<PlayerMovement>().enabled = true;
        }
        
    }
}
