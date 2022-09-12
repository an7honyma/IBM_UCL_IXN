using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public Slider musicSlider;

    void Awake()
    {
        // Set background music slider volume to existing volume level:
        musicSlider.value = VolumeManager.musicVolume;
    }

    void Update()
    {
        // Update volume value for background music:
        VolumeManager.musicVolume = musicSlider.value;
    }
}
