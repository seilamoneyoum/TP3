using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAction : MonoBehaviour
{
    protected GameObject door;
    protected Door doorComponent;
    protected AudioSource audioSource;
    protected GameManager gameManager;
    protected void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        doorComponent = gameObject.GetComponent<Door>();
        door = doorComponent.GetDoor();
        GameObject gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();

    }

}
