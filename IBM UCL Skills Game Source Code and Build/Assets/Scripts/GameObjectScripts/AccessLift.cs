using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AccessLift : MonoBehaviour
{
    public GameObject player;
    public GameObject mcqManager;
    public GameObject visualPrompt;
    public AudioSource activateLiftSFX;

    private float distance;
    private float range = 5f;
    private bool terminalCompleted;

    void Update()
    {
        // Update state of whether level terminal is completed:
        terminalCompleted = mcqManager.GetComponent<MCQManager>().isCompleted;
        // Compute distance between player and lift:
        distance = Vector3.Distance(player.transform.position, transform.position);

        // If terminal is compelted:
        if (terminalCompleted)
        {
            // Render interaction visual prompt above lift if terminal is completed:
            visualPrompt.SetActive(true);

            // If player is in range and hotkey is pressed:
            if (distance <= range && Input.GetKeyDown(KeyCode.E))
            {
                // Activate elevator sound:
                activateLiftSFX.volume = VolumeManager.sfxVolume;
                activateLiftSFX.Play();
                // Begin loading next scene:
                StartCoroutine(LoadNextScene());
            }
        }
        else
        {
            // Leave interaction prompt disabled:
            visualPrompt.SetActive(false);
        }
    }

    IEnumerator LoadNextScene()
    {
        // Delay for 1 second:
        yield return new WaitForSeconds(1);
        // Load level scene when player interacts with lift:
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
