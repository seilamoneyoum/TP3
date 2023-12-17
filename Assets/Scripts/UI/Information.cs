using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Information : MonoBehaviour
{
    [SerializeField] private string currentInformation = "";

    protected Text text;

    void Start()
    {
        GameObject messageGameObject = GameObject.Find("MessageText");
        text = messageGameObject.GetComponent<Text>();
    }

    public void ShowInformation()
    {
        text.text = currentInformation;
    }

    public void SetNewInformation(string newInformation)
    {
        this.currentInformation = newInformation;
        ShowInformation();
    }
}
