using System.Collections;
using UnityEngine;

public class DroidCollision : MonoBehaviour
{
    public GameObject spottedMessage;
    public AudioSource detectionSFX;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Play collision sound:
            detectionSFX.volume = VolumeManager.sfxVolume;
            detectionSFX.Play();
            // If droid collides with player, impose time penalty:
            TimeManager.currentTime -= 20f;
            // Display message to scene:
            StartCoroutine(DisplaySpotted());
        }
    }

    IEnumerator DisplaySpotted()
    {
        spottedMessage.SetActive(true);
        // Leave detection message on screen for 3 seconds:
        yield return new WaitForSeconds(3);
        spottedMessage.SetActive(false);
    }
    
}
