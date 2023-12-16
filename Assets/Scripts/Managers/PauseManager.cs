using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private UnityEvent pauseEvent;
    [SerializeField] private UnityEvent unPauseEvent;
    private bool inPause;
    private GameObject pauseText;
    private GameObject pauseBackground;

    private void Start()
    {
        inPause = false;
        pauseText = GameObject.Find("PauseText");
        pauseBackground = GameObject.Find("PauseImage");
        pauseBackground.SetActive(false);
        pauseText.SetActive(false);
    }
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (inPause)
            {
                unPauseEvent.Invoke();
                inPause = false;
                pauseBackground.SetActive(false);
                pauseText.SetActive(false);
            }
            else
            {
                pauseEvent.Invoke();
                inPause = true;
                pauseBackground.SetActive(true);
                pauseText.SetActive(true);

            }
        }
    }

}
