using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour
{
    GameObject moveableObject;
    private void Start()
    {
        MoveableObject moveableGameObject = GetComponent<MoveableObject>();
        moveableObject = moveableGameObject.GetMoveableObject();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            Vector3 newRotation = new Vector3(moveableObject.transform.rotation.x, 0, moveableObject.transform.rotation.z);
            moveableObject.transform.rotation = Quaternion.Euler(newRotation);
        }
    }
}
