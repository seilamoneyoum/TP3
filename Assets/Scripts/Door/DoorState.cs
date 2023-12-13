using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DoorState : MonoBehaviour
{
    protected Door door;
    protected AudioSource audioSource;
    protected CollectibleManager collectibleManager;
    protected DoorManager doorManager;
    protected SoundManager soundManager;
    protected void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        door = GetComponent<Door>();
        GameObject collectibleManagerObject = GameObject.Find("CollectibleManager");
        collectibleManager = collectibleManagerObject.GetComponent<CollectibleManager>();
        GameObject soundManagerObject = GameObject.Find("SoundManager");
        soundManager = soundManagerObject.GetComponent <SoundManager>();  
        doorManager = GetComponent<DoorManager>();
    }

    public abstract void ManageStateChange();

}
