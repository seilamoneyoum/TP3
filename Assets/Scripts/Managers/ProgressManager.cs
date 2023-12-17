using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProgressManager : MonoBehaviour
{
    [SerializeField] private UnityEvent Victory;
    private const int NB_OBSTACLES_TOTAL = 3;
    private int nbObstaclesUnlocked;
    Text text;

    private void Start()
    {
        GameObject messageTextObject = GameObject.Find("ProgressText");
        text = messageTextObject.GetComponent<Text>();
        text.text = "0/3";
    }
    public void AddUnlockProgress()
    {
        nbObstaclesUnlocked++;
        text.text = nbObstaclesUnlocked.ToString() + "/" + NB_OBSTACLES_TOTAL.ToString();
        if (nbObstaclesUnlocked ==  NB_OBSTACLES_TOTAL)
        {
            Victory.Invoke();
        }
    }
}
