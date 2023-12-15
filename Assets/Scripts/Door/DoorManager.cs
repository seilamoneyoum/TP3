using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public enum DoorStateToSwitch { Open, Close}

    private DoorState doorState;
    private DoorStateToSwitch currentState;

    private void OnEnable()
    {
        doorState = GetComponent<DoorState>();
        ChangeDoorState(DoorStateToSwitch.Close);
        
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
        }
        currentState = nextState;
        doorState.enabled = true;

    }
}
