using UnityEngine;

public class TerminalInterface : MonoBehaviour
{
    public GameObject terminalInterface;
    public GameObject terminal;

    void Update()
    {
        // If terminal MCQ interface is active:
        if (terminalInterface.activeSelf == true)
        {
            // Pause time progression:
            Time.timeScale = 0f;
        }
    }

    public void ExitTerminalInterface()
    {
        // Close terminal interface:
        terminalInterface.SetActive(false);
        terminal.GetComponent<CheckPlayerRange>().isInteracting = false;
        // Resume time progression:
        Time.timeScale = 1f;
    }
}
