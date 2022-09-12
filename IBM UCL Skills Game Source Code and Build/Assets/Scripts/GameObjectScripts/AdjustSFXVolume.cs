using UnityEngine;

public class AdjustSFXVolume : MonoBehaviour
{
    void Update()
    {
        // Update sound effect volume according to volume manager:
        gameObject.GetComponent<AudioSource>().volume = VolumeManager.sfxVolume;
    }
}
