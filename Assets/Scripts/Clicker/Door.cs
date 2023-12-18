using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : ClickableObject
{
    [SerializeField] private bool canOpenDoor;
    private Unlock unlockByTool;
    private DoorMove doorMove;
    private void Start()
    {
        canOpenDoor = true;
        if (GetComponent<UnlockByTool>() != null)
        {
            unlockByTool = GetComponent<UnlockByTool>();
            canOpenDoor = false;
        }
        doorMove = GetComponent<DoorMove>();

    }

    public override void OnClick()
    {
        if (!canOpenDoor)
        {
            unlockByTool.TryToUnlock();
            if (!unlockByTool.IsLocked()) canOpenDoor = true;
        } else if (canOpenDoor)
        {
            doorMove.Move();
        }
    }

}
