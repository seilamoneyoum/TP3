using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.InputSystem;
public class Clicker : MonoBehaviour
{
    Camera m_Camera;
    CollectibleManager collectibleManager;
    void Awake()
    {
        m_Camera = Camera.main;
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
                GameObject chosenObject = hit.collider.gameObject;
                Debug.Log(chosenObject.name);
                if (chosenObject.CompareTag("LeftDoor") || chosenObject.CompareTag("RightDoor"))
                {
                    DoorManager doorManager = chosenObject.GetComponent<DoorManager>();
                    DoorState doorState = doorManager.GetDoorStateObject();
                    doorState.ManageStateChange();
                }
                else if (chosenObject.CompareTag("Key"))
                {
                    collectibleManager.AddKey(chosenObject);
                }
                else if (chosenObject.CompareTag("Clue"))
                {
                    collectibleManager.AddClue(chosenObject);
                }
                else if (chosenObject.CompareTag("Drawer"))
                {

                }
                else if (chosenObject.CompareTag("Carpet"))
                {

                }
                else if (chosenObject.CompareTag("Lightswitch"))
                {
                    Light light = chosenObject.GetComponent<Light>();
                    light.ChangeLightState();
                }

                // Use the hit variable to determine what was clicked on.
            }
        }
    }
}