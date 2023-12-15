using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressManager : MonoBehaviour
{
    private const int NB_OBSTACLES_TOTAL = 2;
    private int nbObstaclesUnlocked;
    Text text;

    private void Start()
    {
        GameObject messageTextObject = GameObject.Find("ProgressText");
        text = messageTextObject.GetComponent<Text>();
        text.text = "0/2";
    }
    public void AddUnlockProgress()
    {
        nbObstaclesUnlocked++;
        text.text = nbObstaclesUnlocked.ToString() + "/" + NB_OBSTACLES_TOTAL.ToString();
        if (nbObstaclesUnlocked == NB_OBSTACLES_TOTAL)
        {

        }

    }
}
