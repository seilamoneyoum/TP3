using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public enum DoorStateToSwitch { Open, Close, Locked, Destroy}

    private DoorState doorState;
    private DoorStateToSwitch currentState;

    private void OnEnable()
    {
        doorState = GetComponent<DoorState>();

        if (GetComponent<DoorStateLocked>())
        {
            ChangeDoorState(DoorStateToSwitch.Locked);
        }
        else
        {
            ChangeDoorState(DoorStateToSwitch.Close);
        }
    }

    public DoorStateToSwitch GetDoorState()
    {
        return currentState;
    }

    public DoorState GetDoorStateObject()
    {
        return doorState;
    }
    public void ChangeDoorState(DoorStateToSwitch nextState)
    {
        if (doorState != null)
        {
            doorState.enabled = false;
        }
        currentState = nextState;
        switch (nextState)
        {
            case DoorStateToSwitch.Open:
                {
                    doorState = gameObject.GetComponent<DoorStateOpen>();
                    break;
                }
            case DoorStateToSwitch.Close:
                {
                    doorState = gameObject.GetComponent<DoorStateClose>();
                    break;
                }
            case DoorStateToSwitch.Locked:
                {
                    doorState = gameObject.GetComponent<DoorStateLocked>();
                    break;
                }
        }
        currentState = nextState;
        doorState.enabled = true;

    }
}
