using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    GameObject moveableObject;
    private void Start()
    {
        MoveableObject moveableGameObject = GetComponent<MoveableObject>();
        moveableObject = moveableGameObject.GetMoveableObject();
    }
    private void Awake()
    {
        if (transform.Find("DoorSingle") != null)
        {
            Transform childTransform = transform.Find("DoorSingle");
            moveableObject = childTransform.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            Vector3 newRotation = new Vector3(moveableObject.transform.rotation.eulerAngles.x, 90f, moveableObject.transform.rotation.eulerAngles.z);
            moveableObject.transform.rotation = Quaternion.Euler(newRotation);
        }
    }
}
