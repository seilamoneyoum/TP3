using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private float rotationYOpen;
    private bool isLocked;

    private void Awake()
    {
        if (gameObject.CompareTag("LeftDoor")) 
        {
            rotationYOpen = -90;
        }
        else if (gameObject.CompareTag("RightDoor")) 
        {
            rotationYOpen = 90;
        }

        isLocked = false;
        if (gameObject.GetComponents<Unlock>() != null)
        {
            isLocked = true;
        }
    }

    public float GetRotationYOpen()
    { 
        return rotationYOpen; 
    }


    public bool GetLockedStatus()
    {
        return isLocked;
    }

    public void SetLockedStatus(bool status)
    {
        this.isLocked = status;
    }
}
