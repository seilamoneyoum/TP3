using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.InputSystem;
public class Clicker : MonoBehaviour
{
    const float MAX_DISTANCE = 1;
    Camera m_Camera;
    CollectibleManager collectibleManager;
    
    void Awake()
    {
        m_Camera = Camera.main;
        GameObject collectibleManagerObject = GameObject.Find("CollectibleManager");
        collectibleManager = collectibleManagerObject.GetComponent<CollectibleManager>();
    }
    // Référence: https://learn.unity.com/tutorial/onmousedown#63566bf3edbc2a0285856b5a
    void Update()
    {
        Mouse mouse = Mouse.current;
        if (mouse.leftButton.wasPressedThisFrame)
        {
            Vector3 mousePosition = mouse.position.ReadValue();
            Ray ray = m_Camera.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                float distanceToHit = Vector3.Distance(m_Camera.transform.position, hit.point);
                if (distanceToHit <= MAX_DISTANCE)
                {
                    GameObject chosenObject = hit.collider.gameObject;
                    ClickOnClue(chosenObject);
                    ClickOnCarpet(chosenObject);
                    ClickOnDrawer(chosenObject);
                    ClickOnDoor(chosenObject);
                    ClickOnKey(chosenObject);
                    ClickOnLightSwitch(chosenObject);
                }
                
            }
        }
    }

    private void ClickOnDoor(GameObject chosenObject)
    {
        if (chosenObject.CompareTag("LeftDoor") || chosenObject.CompareTag("RightDoor"))
        {
            DoorManager doorManager = chosenObject.GetComponent<DoorManager>();
            DoorState doorState = doorManager.GetDoorStateObject();
            doorState.ManageStateChange();
        }
    }

    private void ClickOnKey(GameObject chosenObject)
    {
        if (chosenObject.CompareTag("Key"))
        {
            CollectibleInformation collectibleInformation = chosenObject.GetComponent<CollectibleInformation>();
            CollectEffect collectEffect = chosenObject.GetComponent<CollectEffect>();
            collectEffect.AfterCollect();
            collectibleInformation.ShowInformation();
            
            collectibleManager.AddKey(chosenObject);
        }
    }

    private void ClickOnClue(GameObject chosenObject)
    {
        if (chosenObject.CompareTag("Clue"))
        {
            collectibleManager.AddClue(chosenObject);
        }
    }

    private void ClickOnDrawer(GameObject chosenObject)
    {
        if (chosenObject.CompareTag("Drawer"))
        {

        }
    }

    private void ClickOnCarpet(GameObject chosenObject)
    {
        if (chosenObject.CompareTag("Carpet"))
        {

        }
    }

    private void ClickOnLightSwitch(GameObject chosenObject)
    {
        if (chosenObject.CompareTag("Lightswitch"))
        {
            ChangeLight light = chosenObject.GetComponent<ChangeLight>();
            light.ChangeLightState();
        }

    }
}