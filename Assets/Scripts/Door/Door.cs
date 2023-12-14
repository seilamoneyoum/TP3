using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private float rotationXOpen;
    private float rotationXClose;

    private void Awake()
    {
        if (gameObject.CompareTag("LeftDoor")) // Gestion de la porte gauche
        {
            rotationXOpen = 90;
            rotationXClose = 0;
        }
        else if (gameObject.CompareTag("RightDoor")) // Gestion de la porte droite
        {
            rotationXOpen = 180;
            rotationXClose = -90;
        }
    }

    public float GetRotationXOpen()
    { 
        return rotationXOpen; 
    }

    public float GetRotationXClose() 
    {  
        return rotationXClose; 
    }

}
