using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlock : MonoBehaviour
{
    [SerializeField] private string requiredObjectToUnlock = "";
    [SerializeField] private string potentialObjectToUnlockButFail = "";
    [SerializeField] private string unsuccessfulUnlockMessage = "";
    [SerializeField] private string successfulUnlockMessage = "";

    private KeysManager keysManager;
    private CluesManager cluesManager;
    private bool isLocked;
    private Text text;

    private void Start()
    {
        isLocked = true;
        GameObject messageTextObject = GameObject.Find("MessageText");
        GameObject keysManagerObject = GameObject.Find("KeysManager");
        GameObject cluesManagerObject = GameObject.Find("CluesManager");
        keysManager = keysManagerObject.GetComponent<KeysManager>();
        cluesManager = cluesManagerObject.GetComponent<CluesManager>();
        text = messageTextObject.GetComponent<Text>();
    }
    public void TryToUnlock()
    {
        if (keysManager.IsKeyAvailable(requiredObjectToUnlock) || cluesManager.IsClueAvailable(requiredObjectToUnlock))
        {
            isLocked = false;
            text.text = successfulUnlockMessage;
        }
        else if (keysManager.IsKeyAvailable(potentialObjectToUnlockButFail) || cluesManager.IsClueAvailable(potentialObjectToUnlockButFail))
        {
            text.text = unsuccessfulUnlockMessage;
        }


    }

}
