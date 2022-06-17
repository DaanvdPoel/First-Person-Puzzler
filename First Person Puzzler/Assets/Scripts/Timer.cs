using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float startTime;
    public float timeRemaining;
    public Text timerUI;

    private void Start()
    {
        timeRemaining = startTime;
    }

    void Update()
    {
        if(timeRemaining <= 0)
        {
            GameManager.instance.PlayerDied();
        }
        timerUI.text = "Time Remaining: " + timeRemaining.ToString("0.0");
        timeRemaining = timeRemaining - Time.deltaTime;
    }
}
