using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour
{
    private GameObject objectToOpen;
    private void Awake()
    {
        if (transform.Find("DoorSingle") != null)
        {
            Transform childTransform = transform.Find("DoorSingle");
            objectToOpen = childTransform.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            Vector3 newRotation = new Vector3(objectToOpen.transform.rotation.x, 0, objectToOpen.transform.rotation.z);
            objectToOpen.transform.rotation = Quaternion.Euler(newRotation);
        }
    }
}
