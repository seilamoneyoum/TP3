using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR;
using System.Collections.Generic;
using UnityEngine.Events;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private UnityEvent pauseEvent;
    [SerializeField] private UnityEvent unPauseEvent;
    private bool inPause;
    Text pauseText;

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            pauseText = GameObject.Find("PauseText").GetComponent<Text>();
            if (inPause)
            {
                unPauseEvent.Invoke();
                inPause = false;
                pauseText.text = "";

            }
            else
            {
                pauseEvent.Invoke();
                inPause = true;
                pauseText.text = "Appuyez sur le bouton \"P\" pour continuer la partie";

            }
        }
    }
}
