using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStateClose : DoorState
{
    public override void ManageStateChange()
    {
        audioSource.clip = soundManager.OpenDoorClip;
        audioSource.Play();
        Vector3 currentRotation = door.transform.rotation.eulerAngles;
        currentRotation.y -= door.GetRotationYOpen();
        door.transform.rotation = Quaternion.Euler(currentRotation);
        doorManager.ChangeDoorState(DoorManager.DoorStateToSwitch.Open);
    }

}
