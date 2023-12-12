using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : DoorAction
{
    private void OnTriggerExit(Collider other)
    {
        if (doorComponent.IsLocked() == false)
        {
            audioSource.Play();
            Vector3 newRotation = new Vector3(door.transform.rotation.x, 0, door.transform.rotation.z);
            door.transform.rotation = Quaternion.Euler(newRotation);
        }
    }
}
