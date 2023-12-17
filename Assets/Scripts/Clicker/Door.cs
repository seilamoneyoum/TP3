using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : ClickableObject
{
    public override void OnClick()
    {
        DoorManager doorManager = GetComponent<DoorManager>();
        DoorState doorState = doorManager.GetDoorStateObject();
        doorState.ManageStateChange();
    }

}
