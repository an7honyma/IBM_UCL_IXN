using UnityEngine;

public class VolumeManager : MonoBehaviour
{
    public static float sfxVolume = 0.5f;
    public static float musicVolume = 0.1f;
    private static VolumeManager volumeManager;

    void Awake()
    {
        DontDestroyOnLoad(this);
        // Delete ducplicates when returning to main menu scene:
        if (volumeManager == null)
        {
            volumeManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
        // Get volume of background music:
        gameObject.GetComponent<AudioSource>().volume = musicVolume;
        // Play background music:
        gameObject.GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        // Update background music volume:
        gameObject.GetComponent<AudioSource>().volume = musicVolume;
    }
}
