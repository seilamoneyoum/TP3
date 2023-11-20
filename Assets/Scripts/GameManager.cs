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
    private const int POINTS_PER_REMAINING_SECONDS = 100;
    private const int INDEX_FOR_TITLE = 0;
    private const int INDEX_FOR_MAIN = 1;
    private const int INDEX_FOR_END = 2;
    private static GameManager instance = null;
    public static GameManager Instance { get { return instance; } }
    private int actualScene = 0;
    bool scenesAreInTransition = false;
    private bool gameStart = false;
    private float remainingTime = 480;
    List<GameObject> clues = new List<GameObject>();
    List<GameObject> keys = new List<GameObject>();
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
        if (gameStart == true)
        {
            UpdateTime();
        }
        else
        {
            if (Input.GetButtonDown("Submit")) LoadScene(0, INDEX_FOR_MAIN);

        }
    }

    public void AddKey(GameObject gameObject)
    {
        keys.Add(gameObject);
        nbKeysText = GameObject.Find("NbKeysText").GetComponent<Text>();
        nbKeysText.text = keys.Count.ToString() + "/" + NB_TOTAL_KEYS;
    }

    public void AddHint(GameObject gameObject)
    {
        clues.Add(gameObject);
        nbCluesText = GameObject.Find("NbCluesText").GetComponent<Text>();
        nbCluesText.text = keys.Count.ToString() + "/" + NB_TOTAL_CLUES;
    }

    private void UpdateTime()
    {
        timeText = GameObject.Find("TimeText").GetComponent<Text>();
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
            gameStart = false;
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
                gameStart = true;
                actualScene = INDEX_FOR_MAIN;
                SceneManager.LoadScene("Main");
                break;
            case 2:
                actualScene = INDEX_FOR_END;
                SceneManager.LoadScene("End");
                break;
        }

        scenesAreInTransition = false;
    }



}