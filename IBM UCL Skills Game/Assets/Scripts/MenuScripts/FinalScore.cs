using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    void Awake()
    {
        // Set final score to seconds remaining in time manager:
        finalScoreText.text = $"Final Score: {TimeManager.currentTime}";
    }
}
