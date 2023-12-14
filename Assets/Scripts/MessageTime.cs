using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageTime : MonoBehaviour
{
    const float MAX_SECONDS_TO_SHOW_MESSAGE = 10;
    string currentMessage;
    Text text;
    float remainingTimeToShowMessage;
    GameObject backgroundText;
    bool handleTimeForMessage = true;
    private void Start()
    {
        text = GetComponent<Text>();
        currentMessage = text.text;
        text.enabled = false;
        remainingTimeToShowMessage = 0;
        backgroundText = GameObject.Find("MessageBackground");
        backgroundText.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (handleTimeForMessage)
        {
            if (text.text != currentMessage)
            {
                text.enabled = true;
                remainingTimeToShowMessage = MAX_SECONDS_TO_SHOW_MESSAGE;
                currentMessage = text.text;
                backgroundText.SetActive(true);
            }

            if (remainingTimeToShowMessage > 0)
            {
                remainingTimeToShowMessage -= Time.deltaTime;
                if (remainingTimeToShowMessage < 0)
                {
                    remainingTimeToShowMessage = 0;
                    currentMessage = "";
                    text.text = currentMessage;
                    text.enabled = false;
                    backgroundText.SetActive(false);
                }
            }
        }

    }

    public void SetHandleTimeForMessage(bool status)
    {
        this.handleTimeForMessage = status;
        if (remainingTimeToShowMessage > 0)
        {
            text.enabled = status;
            backgroundText.SetActive(status);
        }
    }
}
