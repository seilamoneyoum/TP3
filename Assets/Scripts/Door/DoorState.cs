using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DoorState : MonoBehaviour
{
    protected Door door;
    protected AudioSource audioSource;
    protected KeysManager keysManager;
    protected DoorManager doorManager;
    protected SoundManager soundManager;
    protected void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        door = GetComponent<Door>();
        GameObject keysManagerObject = GameObject.Find("KeysManager");
        keysManager = keysManagerObject.GetComponent<KeysManager>();
        GameObject soundManagerObject = GameObject.Find("SoundManager");
        soundManager = soundManagerObject.GetComponent <SoundManager>();  
        doorManager = GetComponent<DoorManager>();
    }

    public abstract void ManageStateChange();

}
