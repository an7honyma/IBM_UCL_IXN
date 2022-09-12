using UnityEngine;

public class PausedIcon : MonoBehaviour
{
    public GameObject pausedIcon;

    void Update()
    {
        // If paused:
        if (Time.timeScale == 0)
        {
            // Display puased icon if paused:
            pausedIcon.SetActive(true);
        }
        // If unpaused:
        else
        {
            // Do not display if otherwise:
            pausedIcon.SetActive(false);
        }
    }
}
