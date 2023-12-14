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
    private const int SECONDS_IN_ONE_MIN = 60;
    private bool timeResume = true;
    Text timeText;
    private float remainingTime = 300;

    void Update()
    {
        if (timeResume == true)
        {
            timeText = GameObject.Find("TimeText").GetComponent<Text>();
            int minutes = (int)(Mathf.Floor(remainingTime / SECONDS_IN_ONE_MIN));
            int seconds = (int)(remainingTime % SECONDS_IN_ONE_MIN);
            string secondsFormat = " : ";
            if (seconds < 0)
            {
                secondsFormat = " : 0";
            }
            timeText.text = minutes + secondsFormat + seconds;

            remainingTime -= Time.deltaTime;
            if (remainingTime <= 0)
            {
                GameObject gameManagerObject = GameObject.Find("GameManager");
                GameManager gameManager = gameManagerObject.GetComponent<GameManager>();
                timeResume = false;
                gameManager.LoadScene(1, GameManager.INDEX_FOR_END);
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
