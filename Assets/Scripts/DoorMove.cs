using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    private bool isOpen;
    private AudioSource audioSource;
    private SoundManager soundManager;
    private float rotationYOpen;

    private void Start()
    {
        GameObject finderObject = GameObject.Find("Finder");
        Finder finder = finderObject.GetComponent<Finder>();
        if (gameObject.CompareTag("LeftDoor"))
        {
            rotationYOpen = 90;
        }
        else if (gameObject.CompareTag("RightDoor"))
        {
            rotationYOpen = -90;
        }
        isOpen = false;
        audioSource = GetComponent<AudioSource>();
        soundManager = finder.GetSoundManager();
    }

    public void Move()
    {
        if (!audioSource.isPlaying)
        {
            Vector3 currentRotation = transform.rotation.eulerAngles;

            if (!isOpen)
            {
                currentRotation.y += rotationYOpen;
                audioSource.clip = soundManager.OpenDoorClip;
                isOpen = true;
            }
            else
            {
                currentRotation.y -= rotationYOpen;
                audioSource.clip = soundManager.CloseDoorClip;
                isOpen = false;
            }
            audioSource.Play();
            transform.rotation = Quaternion.Euler(currentRotation);

        }
    }

}
