using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountUp : MonoBehaviour
{
    public bool timeActive = true;

    public TextMeshProUGUI timerText;
    private float secondsCount;
    private int minutesCount;

    void Update()
    {
        if (timeActive)
        {
            UpdateTimerUI();
        }
    }

    public void UpdateTimerUI()
    {
        secondsCount += Time.deltaTime;

        string secondsText = "";
        string minutesText = "";

        if (secondsCount < 10)
        {
            secondsText = "0" + (int)secondsCount;
        } else
        {
            secondsText = "" + (int)secondsCount;
        }

        if (minutesCount < 10)
        {
            minutesText = "0" + (int)minutesCount;
        }
        else
        {
            minutesText = "" + (int)minutesCount;
        }

        timerText.text = minutesText + ":" + secondsText;

        if (secondsCount >= 60)
        {
            minutesCount++;
            secondsCount = 0;
        }
    }
}
