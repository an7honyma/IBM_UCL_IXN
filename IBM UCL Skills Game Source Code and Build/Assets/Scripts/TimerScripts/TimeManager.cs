using UnityEngine.SceneManagement;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static float initialTime = 900f;
    public static float currentTime;
    public static bool gameCompleted;
    public GameObject timer;

    void Start()
    {
        gameCompleted = false;
        // Set variable for recursion to initial value:
        currentTime = initialTime;
        // Invoke method 1 second after start, and repeat every 1 second:
        InvokeRepeating("Decrement", 1f, 1f);
    }

    void Update()
    {
        if (currentTime <= 0)
            {
                // Suspend game progression:
                Time.timeScale = 0f;
                // Find and destroy timer. Timer will be automatically reloaded and reset on first level if player decides to replay:
                timer = GameObject.FindWithTag("Timer");
                Destroy(timer);
                EnterLoseScene();
            }
    }

    void Decrement()
    {
        if (!gameCompleted)
        {
            // Continue decrementing timer if game is not completed:
            currentTime -= 1f;
        }
        
    }

    void EnterLoseScene()
    {
        // Load lost game scene:
        SceneManager.LoadScene("LoseScene");
    }
}
