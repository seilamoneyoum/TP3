using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStateOpen : DoorState
{
    public override void ManageStateChange()
    {
        if (canMove && !audioSource.isPlaying)
        {
            audioSource.clip = soundManager.CloseDoorClip;
            audioSource.Play();
            Vector3 currentRotation = transform.rotation.eulerAngles;
            currentRotation.y += rotationYOpen;
            transform.rotation = Quaternion.Euler(currentRotation);
            doorManager.ChangeDoorState(DoorManager.DoorStateToSwitch.Close);
        }
    }
}
