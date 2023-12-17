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
    [SerializeField] private float remainingTime = 10;
    private GameManager gameManager;
    private AudioSource mainCameraAudioSource;
    private SoundManager soundManager;
    private bool timeResume;
    private Text timeText;

    private void OnEnable()
    {
        timeResume = true;
        GameObject finderObject = GameObject.Find("Finder");
        Finder finder = finderObject.GetComponent<Finder>();
        gameManager = finder.GetGameManager();
        mainCameraAudioSource = finder.GetMainCameraAudioSource();
        soundManager = finder.GetSoundManager();
    }

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
                GameOverHandler();
            }
        }
    }

    private void GameOverHandler()
    {
        mainCameraAudioSource.clip = soundManager.GameOverClip;
        mainCameraAudioSource.Play();
        gameManager.LoadScene(soundManager.GameOverClip.length, 3);
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
