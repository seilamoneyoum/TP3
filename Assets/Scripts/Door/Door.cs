using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private GameObject door;
    private bool isLocked = false;
    private float rotationX = 0;
    private void Awake()
    {
        if (transform.Find("DoorSingle") != null)
        {
            Transform childTransform = transform.Find("DoorSingle");
            door = childTransform.gameObject;
            if (gameObject.GetComponent<Unlock>())
            {
                isLocked = true;
            }
        }
    }

    public bool IsLocked()
    {
        return isLocked;
    }
    public GameObject GetDoor()
    {
        return door;
    }

    public void Unlock()
    {
        this.isLocked = true;
    }
}
