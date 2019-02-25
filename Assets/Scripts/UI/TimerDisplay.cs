using UnityEngine;
using System.Collections;
using TMPro;
using System;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private Timer timer;


    private void Start()
    {
        timer.OnTimeChanged += UpdateDisplay;
    }

    private void UpdateDisplay(int elapsedSeconds)
    {
        var timeSpan = new TimeSpan(0, 0, elapsedSeconds);
        string timerText = timeSpan.ToString(@"mm\:ss");
        text.text = timerText;
    }
}
