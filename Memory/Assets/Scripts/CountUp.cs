using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountUp : MonoBehaviour
{
    public bool timeActive = true;

    public TextMeshProUGUI timerText;
    private float secondsCount;
    private int minuteCount;

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
        timerText.text = minuteCount + "m:" + (int)secondsCount + "s";

        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
    }
}
