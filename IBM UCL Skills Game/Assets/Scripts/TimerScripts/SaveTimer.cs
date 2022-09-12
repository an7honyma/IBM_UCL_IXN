using UnityEngine;

public class SaveTimer : MonoBehaviour
{
    void Start()
    {
        // Preserve timer throughout loading subsequent game level scenes:
        DontDestroyOnLoad(transform.gameObject);
    }
}
