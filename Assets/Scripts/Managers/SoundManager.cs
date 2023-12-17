using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource currentSceneAudioSource;
    private static SoundManager instance = null;
    public static SoundManager Instance { get { return instance; } }
    [SerializeField] private AudioClip collectKey;
    [SerializeField] private AudioClip collectClue;
    [SerializeField] private AudioClip openDoor;
    [SerializeField] private AudioClip closeDoor;
    [SerializeField] private AudioClip chainsaw;
    [SerializeField] private AudioClip removeWedge;
    [SerializeField] private AudioClip gameOver;
    public AudioClip CollectKeyClip { get { return collectKey; } }
    public AudioClip CollectClueClip { get { return collectClue; } }
    public AudioClip OpenDoorClip { get { return openDoor; } }
    public AudioClip CloseDoorClip { get { return closeDoor; } }

    public AudioClip ChainsawClip { get { return chainsaw; } }
    public AudioClip RemoveWedgeClip { get { return removeWedge; } }
    public AudioClip GameOverClip { get { return gameOver;  } }
    void Awake()
    {

        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);
    }



}

