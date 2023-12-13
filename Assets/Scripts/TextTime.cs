using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTime : MonoBehaviour
{
    const float MAX_SECONDS_TO_SHOW_MESSAGE = 10;
    string currentMessage;
    Text text;
    float remainingTimeToShowMessage;

    private void Start()
    {
        text = GetComponent<Text>();
        currentMessage = text.text;
        remainingTimeToShowMessage = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (text.text != currentMessage)
        {
            remainingTimeToShowMessage = MAX_SECONDS_TO_SHOW_MESSAGE;
            currentMessage = text.text;
        }

        if (remainingTimeToShowMessage > 0)
        {
            remainingTimeToShowMessage -= Time.deltaTime;
            if (remainingTimeToShowMessage < 0)
            {
                remainingTimeToShowMessage = 0;
                currentMessage = "";
                text.text = currentMessage;
            }
        }
    }
}
