using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class DoorState : MonoBehaviour
{
    protected bool canMove;
    protected UnlockByTool unlock;
    protected AudioSource audioSource;
    protected DoorManager doorManager;
    protected SoundManager soundManager;
    protected ProgressManager progressManager;
    protected float rotationYOpen;
    private Finder finder;

    protected void Start()
    {
        if (gameObject.CompareTag("LeftDoor"))
        {
            rotationYOpen = -90;
        }
        else if (gameObject.CompareTag("RightDoor"))
        {
            rotationYOpen = 90;
        }

        canMove = true;
        if (gameObject.GetComponent<UnlockByTool>() != null)
        {
            unlock = gameObject.GetComponent<UnlockByTool>();
            if (unlock.IsLocked())
            {
                canMove = false;
            }
        }

        GameObject finderObject = GameObject.Find("Finder");
        finder = finderObject.GetComponent<Finder>();
        audioSource = gameObject.GetComponent<AudioSource>();
        soundManager = finder.GetSoundManager();
        progressManager = finder.GetProgressManager();
        doorManager = GetComponent<DoorManager>();
    }

    public abstract void ManageStateChange();

}
