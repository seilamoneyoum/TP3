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
    Text pauseText;
    private GameObject pauseBackground;
    private GameObject firstPersonCamera;
    private void Start()
    {
        pauseBackground = GameObject.Find("PauseImage");
        pauseBackground.SetActive(false);
        firstPersonCamera = GameObject.Find("First Person Camera");
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            pauseText = GameObject.Find("PauseText").GetComponent<Text>();
            if (inPause)
            {
                firstPersonCamera.SetActive(true);
                pauseBackground.SetActive(false);
                unPauseEvent.Invoke();
                inPause = false;
                pauseText.text = "";

            }
            else
            {
                firstPersonCamera.SetActive(false);
                pauseBackground.SetActive(true);
                pauseEvent.Invoke();
                inPause = true;
                pauseText.text = "Appuyez sur le bouton \"P\" pour continuer la partie";

            }
        }
    }
}
