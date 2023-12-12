using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : DoorAction
{
    private void OnTriggerEnter(Collider other)
    {
        if (doorComponent.IsLocked() == false)
        {
            audioSource.Play();
            Vector3 newRotation = new Vector3(door.transform.rotation.eulerAngles.x, 90f, door.transform.rotation.eulerAngles.z);
            door.transform.rotation = Quaternion.Euler(newRotation);
        }
    }
}
