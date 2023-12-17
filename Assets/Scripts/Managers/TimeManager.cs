using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR;
using System.Collections.Generic;
using UnityEngine.Events;


public class TimeManager : MonoBehaviour
{
    [SerializeField] private UnityEvent GameOver;
    private const int SECONDS_IN_ONE_MIN = 60;
    private bool timeResume = true;
    private Text timeText;
    private float remainingTime = 480;

    void Update()
    {
        if (timeResume == true)
        {
            timeText = GameObject.Find("TimeText").GetComponent<Text>();
            int minutes = (int)(Mathf.Floor(remainingTime / SECONDS_IN_ONE_MIN));
            int seconds = (int)(remainingTime % SECONDS_IN_ONE_MIN);
            string secondsFormat = " : ";
            if (seconds < 10)
            {
                secondsFormat = " : 0";
            }
            timeText.text = minutes + secondsFormat + seconds;

            remainingTime -= Time.deltaTime;
            if (remainingTime <= 0)
            {
                timeResume = false;
                GameOver.Invoke();
            }
        }
    }

    public bool TimeIsResumed()
    {
        return timeResume;
    }

    public void SetTimeResume(bool canResume)
    {
        timeResume = canResume;
    }

}
