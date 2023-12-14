using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleInformation : MonoBehaviour
{
    [SerializeField] private string information;
    Text text;
    void Start()
    {
        GameObject messageGameObject = GameObject.Find("MessageText");
        text = messageGameObject.GetComponent<Text>();
    }

    public void ShowInformation()
    {
        text.text = information;
    }
}
