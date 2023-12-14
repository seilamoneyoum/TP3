using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private float rotationYOpen;
    private float rotationYClose;

    private void Awake()
    {
        if (gameObject.CompareTag("LeftDoor")) // Gestion de la porte gauche
        {
            rotationYClose = -180;
            rotationYOpen = -90;
        }
        else if (gameObject.CompareTag("RightDoor")) // Gestion de la porte droite
        {
            rotationYClose = 180;
            rotationYOpen = 90;
        }
    }

    public float GetRotationYOpen()
    { 
        return rotationYOpen; 
    }

    public float GetRotationYClose() 
    {  
        return rotationYClose; 
    }

}
