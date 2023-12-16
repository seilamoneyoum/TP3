using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearOutOfObject : MonoBehaviour
{
    
    public void Show()
    {
        Vector3 newPosition = transform.position;
        newPosition.y *= 2.5f;
        transform.position = newPosition;
    }
}
