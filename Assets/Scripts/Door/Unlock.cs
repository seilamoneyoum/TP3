using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlock : DoorAction
{
    const string CAN_UNLOCK_MESSAGE = "J'ai un pied de biche. Enfin, je peux retirer la cale de porte. ";
    const string CAN_NOT_UNLOCK_MESSAGE = "La porte est bloquée... Par un cale de porte? Je dois trouver quelque chose dans la salle de bain pour sortir.";
    const float TIME_TO_REMOVE_WEDGE = 5;

    Text text;
    float remainingTimeToRemoveWedge;
    
    private void OnTriggerEnter(Collider other)
    {
        if (doorComponent.IsLocked())
        {
            text = GameObject.Find("MessageText").GetComponent<Text>();

            if (gameManager.IsKeyAvailable("Crowbar"))
            {
                text.text = CAN_UNLOCK_MESSAGE;
                remainingTimeToRemoveWedge = TIME_TO_REMOVE_WEDGE;
            }
            else
            {
                text.text = CAN_NOT_UNLOCK_MESSAGE;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (doorComponent.IsLocked())
        {
            remainingTimeToRemoveWedge -= Time.deltaTime;
            if (remainingTimeToRemoveWedge < 0) doorComponent.Unlock();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (doorComponent.IsLocked()) text.text = "";
    }
}
