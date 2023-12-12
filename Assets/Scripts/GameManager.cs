using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR;
using System.Collections.Generic;
using UnityEngine.Events;
using System;

public class GameManager : MonoBehaviour
{
    private const int NB_TOTAL_KEYS = 5;
    private const int NB_TOTAL_CLUES = 8;
    public const int INDEX_FOR_TITLE = 0;
    public const int INDEX_FOR_MAIN = 1;
    public const int INDEX_FOR_END = 2;
    private static TimeManager timeManager;
    private static GameManager instance = null;
    public static GameManager Instance { get { return instance; } }
    private int actualScene = 0;
    bool scenesAreInTransition = false;
    private List<GameObject> keys = new List<GameObject>();
    private List<GameObject> clues = new List<GameObject>();
    private bool hasWon = false;
    Text nbCluesText;
    Text nbKeysText;
    Text gameStatusText;
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

    }


    public void AddKey(GameObject gameObject)
    {
        keys.Add(gameObject);
        nbKeysText = GameObject.Find("NbKeysText").GetComponent<Text>();
        nbKeysText.text = keys.Count.ToString() + "/" + NB_TOTAL_KEYS;
    }

    public void AddClue(GameObject gameObject)
    {
        clues.Add(gameObject);
        nbCluesText = GameObject.Find("NbCluesText").GetComponent<Text>();
        nbCluesText.text = clues.Count.ToString() + "/" + NB_TOTAL_CLUES;
    }

    public bool IsKeyAvailable(string name)
    {
        foreach (GameObject key in keys)
        {
            if (key.name.Equals(name)) return true;
        }
        return false;
    }


    public void LoadScene(float delay, int scene)
    {
        if (scenesAreInTransition) return;  //Pour �viter plusieurs transitions lanc�es en bloc

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
                actualScene = INDEX_FOR_END;
                SceneManager.LoadScene("End");
                break;
        }

        scenesAreInTransition = false;
    }



}