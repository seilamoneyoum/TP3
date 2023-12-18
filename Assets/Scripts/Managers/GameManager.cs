using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.XR;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;
using System;

public class GameManager : MonoBehaviour
{

    public const int INDEX_FOR_TITLE = 0;
    public const int INDEX_FOR_MAIN = 1;
    public const int INDEX_FOR_END_VICTORY = 2;
    public const int INDEX_FOR_END_LOSS = 3;
    private static GameManager instance = null;
    public static GameManager Instance { get { return instance; } }
    private int actualScene = 0;
    private bool scenesAreInTransition = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);

        }

    }

    void Start()
    {
        actualScene = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel")) Application.Quit();
        if (Input.GetButtonDown("Submit"))
        {
            if (actualScene == INDEX_FOR_TITLE) LoadScene(1, INDEX_FOR_MAIN);
            if (actualScene == INDEX_FOR_END_VICTORY || actualScene == INDEX_FOR_END_LOSS) LoadScene(1, INDEX_FOR_TITLE);
        }
    }

    public void LoadScene(float delay, int scene)
    {
        if (scenesAreInTransition) return;  //Pour éviter plusieurs transitions lancées en bloc

        scenesAreInTransition = true;

        StartCoroutine(RestartLevelDelay(delay, scene));
    }

    private IEnumerator RestartLevelDelay(float delay, int scene)
    {
        yield return new WaitForSeconds(delay);
        switch(scene)
        {
            case 0:
                actualScene = INDEX_FOR_TITLE;
                SceneManager.LoadScene("Title");
                break;
            case 1:
                actualScene = INDEX_FOR_MAIN;
                SceneManager.LoadScene("Main");
                break;
            case 2:
                actualScene = INDEX_FOR_END_VICTORY;
                SceneManager.LoadScene("Victory");
                break;
            case 3:
                actualScene = INDEX_FOR_END_LOSS;
                SceneManager.LoadScene("GameOver");
                break;
        }

        scenesAreInTransition = false;
    }



}