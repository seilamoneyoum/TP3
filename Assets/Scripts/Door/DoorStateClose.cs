using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStateClose : DoorState
{
    public override void ManageStateChange()
    {
        if (!audioSource.isPlaying)
        {
            if (!canMove)
            {
                unlock.TryToUnlock();
                if (!unlock.IsLocked()) canMove = true;
            }
            else 
            {
                audioSource.clip = soundManager.OpenDoorClip;
                audioSource.Play();
                Vector3 currentRotation = transform.rotation.eulerAngles;
                currentRotation.y -= rotationYOpen;
                transform.rotation = Quaternion.Euler(currentRotation);
                doorManager.ChangeDoorState(DoorManager.DoorStateToSwitch.Open);
            }
        }

    }

}
