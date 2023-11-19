using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
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

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            Vector3 newRotation = new Vector3(objectToOpen.transform.rotation.eulerAngles.x, 90f, objectToOpen.transform.rotation.eulerAngles.z);
            objectToOpen.transform.rotation = Quaternion.Euler(newRotation);
        }
    }
}
