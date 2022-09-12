using UnityEngine;

/*
REFERENCES:
Mini Unity Tutorial - How to Add Sound Effects (Youtube/Jimmy Vegas):
https://www.youtube.com/watch?v=JnbDxG04i7c

*/

public class MenuButtonSounds : MonoBehaviour
{
    public AudioSource buttonSelectSFX;

    public void PlayButtonSound()
    {
        buttonSelectSFX.volume = VolumeManager.sfxVolume;
        buttonSelectSFX.Play();
    }
}
