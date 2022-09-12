using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    public GameObject timer;
    
    public void DeleteTimer()
    {
        // Find and destroy timer. Timer will be automatically reloaded and reset on first level if player decides to replay:
        timer = GameObject.FindWithTag("Timer");
        Destroy(timer);
    }
}
