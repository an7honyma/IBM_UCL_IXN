using UnityEngine;
using UnityEngine.UI;

public class SFXManager : MonoBehaviour
{
    public Slider sfxSlider;

    void Awake()
    {
        // Set sfx slider volume to existing volume level:
        sfxSlider.value = VolumeManager.sfxVolume;
    }

    void Update()
    {
        // Update volume value for sfx:
        VolumeManager.sfxVolume = sfxSlider.value;
    }
}
