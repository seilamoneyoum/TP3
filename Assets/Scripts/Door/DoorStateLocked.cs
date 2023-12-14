using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorStateLocked : DoorState
{
    const string CAN_UNLOCK_MESSAGE = "J'ai un pied de biche. Enfin, je peux retirer la cale de porte.";
    const string CAN_NOT_UNLOCK_MESSAGE = "La porte est bloquée... Par un cale de porte? Je dois trouver quelque chose dans la salle de bain pour sortir.";
    Text text;

    public override void ManageStateChange()
    {
        text = GameObject.Find("MessageText").GetComponent<Text>();

        if (keysManager.IsKeyAvailable("Crowbar"))
        {
            text.text = CAN_UNLOCK_MESSAGE;
            StartCoroutine(UnlockThenOpenDoor());
        }
        else
        {
            text.text = CAN_NOT_UNLOCK_MESSAGE;
        }
    }
    IEnumerator UnlockThenOpenDoor()
    {
        audioSource.clip = soundManager.RemoveWedgeClip;
        audioSource.Play();

        yield return new WaitForSeconds(audioSource.clip.length);

        audioSource.clip = soundManager.OpenDoorClip;
        audioSource.Play();
        Vector3 currentRotation = door.transform.rotation.eulerAngles;
        currentRotation.y -= door.GetRotationYOpen();
        door.transform.rotation = Quaternion.Euler(currentRotation);
        doorManager.ChangeDoorState(DoorManager.DoorStateToSwitch.Open);
    }

}
