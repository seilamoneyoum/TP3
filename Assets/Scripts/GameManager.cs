using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private const int NB_TOTAL_KEYS = 5;
    private const int NB_TOTAL_CLUES = 10;
    private const int SECONDS_IN_ONE_MIN = 60;
    private const int INDEX_FOR_TITLE = 0;
    private const int INDEX_FOR_MAIN = 1;
    private const int INDEX_FOR_END = 2;
    private static GameManager instance = null;
    public static GameManager Instance { get { return instance; } }
    private int actualScene = 0;
    bool scenesAreInTransition = false;
    private bool inPause;
    private float remainingTime = 480;
    private int currentNbKeys = 0;
    private int currentNbClues = 0;
    private 
    Text pauseText;
    Text nbCluesText;
    Text nbKeysText;
    Text timeText;
    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
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
            if (actualScene == INDEX_FOR_TITLE) LoadScene(0, INDEX_FOR_MAIN);
            if (actualScene == INDEX_FOR_END) LoadScene(0, INDEX_FOR_TITLE);
        }
        if (actualScene == INDEX_FOR_MAIN)
        {
            nbCluesText = GameObject.Find("NbCluesText").GetComponent<Text>();
            nbKeysText = GameObject.Find("NbKeysText").GetComponent<Text>();
            pauseText = GameObject.Find("PauseText").GetComponent<Text>();
            timeText = GameObject.Find("TimeText").GetComponent<Text>();
            if (inPause == false)
            {
                UpdateTime();
            }

            if (Input.GetButtonDown("Pause"))
            {

                if (inPause)
                {
                    inPause = true;
                    pauseText.text = "Appuyez sur le bouton \"P\" pour continuer la partie";
                }
                else
                {
                    inPause = true;
                    pauseText.text = "";
                }
            }
        }

    }

    public bool IsInPause()
    {
        return inPause;
    }

    public void AddKey()
    {
        currentNbKeys++;
        nbKeysText.text = currentNbKeys.ToString() + "/" + NB_TOTAL_KEYS;
    }

    public void AddHint()
    {
        currentNbClues++;
        nbCluesText.text = currentNbClues.ToString() + "/" + NB_TOTAL_CLUES;
    }

    private void UpdateTime()
    {
        int minutes = (int)(Mathf.Floor(remainingTime / SECONDS_IN_ONE_MIN));
        int seconds = (int)(remainingTime % SECONDS_IN_ONE_MIN);
        if (seconds < 10)
        {
            timeText.text = minutes + " : 0" + seconds;
        }
        else
        {
            timeText.text = minutes + " : " + seconds;

        }
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0)
        {
            inPause = true;
            LoadScene(20, INDEX_FOR_END);
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
                inPause = false;
                break;
            case 2:
                actualScene = INDEX_FOR_END;
                SceneManager.LoadScene("End");
                break;
        }

        scenesAreInTransition = false;
    }



}