using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.InputSystem;
public class Clicker : MonoBehaviour
{
    private const float MAX_DISTANCE = 1.3f;
    private Camera m_Camera;
    private Finder finder;
    private ToolsManager toolsManager;
    private CluesManager cluesManager;
    
    void Awake()
    {
        m_Camera = Camera.main;
        GameObject finderObject = GameObject.Find("Finder");
        finder = finderObject.GetComponent<Finder>();
        toolsManager = finder.GetToolsManager();
        cluesManager = finder.GetCluesManager();
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
                    ClickOnDoor(chosenObject);
                    ClickOnTool(chosenObject);
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

    private void ClickOnTool(GameObject chosenObject)
    {
        if (chosenObject.CompareTag("Tool"))
        {
            Information information = chosenObject.GetComponent<Information>();
            CollectEffect collectEffect = chosenObject.GetComponent<CollectEffect>();
            collectEffect.AfterCollect();
            information.ShowInformation();
            toolsManager.AddTool(chosenObject);


        }
    }

    private void ClickOnClue(GameObject chosenObject)
    {
        if (chosenObject.CompareTag("Clue"))
        {
            Information information = chosenObject.GetComponent<Information>();
            CollectEffect collectEffect = chosenObject.GetComponent<CollectEffect>();
            collectEffect.AfterCollect();
            information.ShowInformation();
            cluesManager.AddClue(chosenObject);


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