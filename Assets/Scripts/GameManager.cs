using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const int SECONDS_IN_ONE_MIN = 60;
    private const int POINTS_PER_REMAINING_SECONDS = 100;
    private const int INDEX_FOR_TITLE = 0;
    private const int INDEX_FOR_MAIN = 1;
    private const int INDEX_FOR_END = 2;
    private static GameManager instance = null;
    public static GameManager Instance { get { return instance; } }
    private int actualScene = 0;
    private int score = 0;
    bool scenesAreInTransition = false;
    private bool gameStart = false;
    private float remainingTime = 480;
    Text scoreText;
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
        if (Input.GetButtonDown("Submit")) LoadScene(1, INDEX_FOR_MAIN);
        if (gameStart == true)
        {
            float minutes = Mathf.Floor(remainingTime / SECONDS_IN_ONE_MIN);
            float seconds = remainingTime % SECONDS_IN_ONE_MIN;
            timeText.text = minutes + " : " + seconds;
            remainingTime -= Time.deltaTime;
            if (remainingTime <= 0)
            {
                gameStart = false;
                LoadScene(20, INDEX_FOR_END);
            }


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
                SceneManager.LoadScene("Title");
                break;
            case 1:
                SceneManager.LoadScene("Main");
                break;
            case 2:
                SceneManager.LoadScene("End");
                break;
        }

        scenesAreInTransition = false;
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = score.ToString();
    }

}