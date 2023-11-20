using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour
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

    public GameObject GetMoveableObject()
    {
        return objectToOpen;
    }
}
