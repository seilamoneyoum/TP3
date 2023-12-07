using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCarpet : MonoBehaviour
{
    private const float POSITION_X_TO_MOVE = 1.4f;
    private Vector3 initialPosition;
    private Vector3 positionOnceMoved;

    private void Start()
    {
        initialPosition = transform.position;
        positionOnceMoved = new Vector3(transform.position.x + POSITION_X_TO_MOVE, transform.position.y, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        // Référence: https://discussions.unity.com/t/how-to-detect-mouse-click-on-a-gameobject/59449/7
        
        
        
    }
}
