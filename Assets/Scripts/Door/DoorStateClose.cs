using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStateClose : DoorState
{
    public override void ManageStateChange()
    {
        audioSource.clip = soundManager.OpenDoorClip;
        audioSource.Play();
        Quaternion newRotation = Quaternion.Euler(door.transform.rotation.x, door.GetRotationXOpen(), door.transform.rotation.z);
        door.transform.rotation = newRotation;
        doorManager.ChangeDoorState(DoorManager.DoorStateToSwitch.Open);
    }

}
