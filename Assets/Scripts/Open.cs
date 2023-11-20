using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    GameObject moveableObject;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        MoveableObject moveableGameObject = GetComponent<MoveableObject>();
        moveableObject = moveableGameObject.GetMoveableObject();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            audioSource.Play();
            Vector3 newRotation = new Vector3(moveableObject.transform.rotation.eulerAngles.x, 90f, moveableObject.transform.rotation.eulerAngles.z);
            moveableObject.transform.rotation = Quaternion.Euler(newRotation);
        }
    
}

}
