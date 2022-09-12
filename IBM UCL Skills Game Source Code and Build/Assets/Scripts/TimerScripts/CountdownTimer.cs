using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CountdownTimer : MonoBehaviour
{
    private float currentTime;
    private float minutesLeft;
    private float secondsLeft;
    private string minutesLeftString;
    private string secondsLeftString;

    public TextMeshProUGUI countdownTimer;

    void Update()
    {
        // Retireve current time from time manager:
        currentTime = TimeManager.currentTime;
        if (currentTime <= 0)
        {
            countdownTimer.text = "00:00";
        }
        else
        {
            if (currentTime <= 60f)
            {
                // If time left reaches below 1 minute, change text colour to red:
                countdownTimer.color = Color.red;
            }
            // Convert to minutes and seconds, and adjust display format:
            minutesLeft = (float)Math.Floor(currentTime / 60);
            secondsLeft = currentTime % 60;
            if (secondsLeft < 10f)
            {
                secondsLeftString = "0" + secondsLeft.ToString("0");
            }
            else
            {
                secondsLeftString = secondsLeft.ToString("0");
            }
            if (minutesLeft < 10f)
            {
                minutesLeftString = "0" + minutesLeft.ToString();
            }
            else
            {
                minutesLeftString = minutesLeft.ToString();
            }
            // Update countdown timer text field:
            countdownTimer.text = minutesLeftString + ":" + secondsLeftString;
        }
    }
}
