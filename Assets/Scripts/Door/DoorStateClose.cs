using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStateClose : DoorState
{
    public override void ManageStateChange()
    {
        audioSource.clip = soundManager.OpenDoorClip;
        audioSource.Play();
        Vector3 newRotation = new Vector3(door.transform.rotation.eulerAngles.x, door.GetRotationXOpen(), door.transform.rotation.eulerAngles.z);
        door.transform.rotation = Quaternion.Euler(newRotation);
        doorManager.ChangeDoorState(DoorManager.DoorStateToSwitch.Open);
    }

}
