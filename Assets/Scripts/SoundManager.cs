using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource mainCameraAudioSource;
    private static SoundManager instance = null;
    public static SoundManager Instance { get { return instance; } }
    private GameObject[] soundPlacements;
    [SerializeField] private AudioClip playerWalk1;
    [SerializeField] private AudioClip playerWalk2;
    [SerializeField] private AudioClip playerWalk3;
    [SerializeField] private AudioClip playerWalk4;
    [SerializeField] private AudioClip playerWalk5;
    [SerializeField] private AudioClip playerWalk6;
    [SerializeField] private AudioClip playerWalk7;
    [SerializeField] private AudioClip playerWalk8;
    [SerializeField] private AudioClip playerWalk9;
    [SerializeField] private AudioClip playerWalk10;
    [SerializeField] private AudioClip collectKey;
    [SerializeField] private AudioClip collectClue;
    [SerializeField] private AudioClip openDoor;
    [SerializeField] private AudioClip closeDoor;
    [SerializeField] private AudioClip openDrawer;
    [SerializeField] private AudioClip closeDrawer;

    public AudioClip PlayerWalk1Clip { get { return playerWalk1; } }
    public AudioClip PlayerWalk2Clip { get { return playerWalk2; } }
    public AudioClip PlayerWalk3Clip { get { return playerWalk3; } }
    public AudioClip PlayerWalk4Clip { get { return playerWalk4; } }
    public AudioClip PlayerWalk5Clip { get { return playerWalk5; } }
    public AudioClip PlayerWalk6Clip { get { return playerWalk6; } }
    public AudioClip PlayerWalk7Clip { get { return playerWalk7; } }
    public AudioClip PlayerWalk8Clip { get { return playerWalk8; } }
    public AudioClip PlayerWalk9Clip { get { return playerWalk9; } }
    public AudioClip PlayerWalk10Clip { get { return playerWalk10; } }

    public AudioClip CollectKeyClip { get { return collectKey; } }
    public AudioClip CollectClueClip { get { return collectClue; } }
    public AudioClip OpenDoorClip { get { return openDoor; } }
    public AudioClip CloseDoorClip { get { return closeDoor; } }
    public AudioClip OpenDrawerClip { get { return openDrawer; } }
    public AudioClip CloseDrawerClip { get { return closeDrawer; } }


    void Start()
    {
        if (instance == null) instance = this;
        else if (instance != this)
            Destroy(gameObject);

        /*soundPlacements = GameObject.FindGameObjectsWithTag("Sound");
        for (int i = 0; i < soundPlacements.Length; i++)
        {
            soundPlacements[i].SetActive(false);
        }*/
    }

    public void PauseGameMusic()
    {
        mainCameraAudioSource.Pause();
    }

    public void UnPauseGameMusic()
    {
        mainCameraAudioSource.UnPause();
    }
    /*
    public void PlaySound(Vector3 position, AudioClip audioClip)
    {
        bool soundPlacementAvailableFound = false;
        while (soundPlacementAvailableFound == false)
        {
            for (int i = 0; i < soundPlacements.Length; i++)
            {
                if (soundPlacements[i].activeSelf == false && soundPlacementAvailableFound == false)
                {
                    soundPlacementAvailableFound = true;
                    soundPlacements[i].SetActive(true);
                    SoundPlacement soundPlacement = soundPlacements[i].GetComponent<SoundPlacement>();
                    soundPlacement.SetPosition(position);
                    soundPlacement.SetSound(audioClip);
                }
            }
        }
    }*/

}

