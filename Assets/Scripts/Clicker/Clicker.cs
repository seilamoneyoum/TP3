using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Clicker : MonoBehaviour
{
    [SerializeField] private UnityEvent Victory;
    [SerializeField] private bool canClickOnObject;
    private const float MAX_DISTANCE = 1.2f;
    private Camera m_Camera;
    private Finder finder;
    private ToolsManager toolsManager;
    private CluesManager cluesManager;
    private void OnEnable()
    {
        GameObject finderObject = GameObject.Find("Finder");
        finder = finderObject.GetComponent<Finder>();
        canClickOnObject = true;
    }

    void Start()
    {
        m_Camera = Camera.main;
        toolsManager = finder.GetToolsManager();
        cluesManager = finder.GetCluesManager();
    }

    // Référence: https://learn.unity.com/tutorial/onmousedown#63566bf3edbc2a0285856b5a
    void Update()
    {
        Mouse mouse = Mouse.current;
        if (mouse.leftButton.wasPressedThisFrame && canClickOnObject)
        {
            Vector3 mousePosition = mouse.position.ReadValue();
            Ray ray = m_Camera.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                float distanceToHit = Vector3.Distance(m_Camera.transform.position, hit.point);
                if (distanceToHit <= MAX_DISTANCE)
                {
                    GameObject chosenObject = hit.collider.gameObject;
                    ClickOnMoveableObject(chosenObject);
                    ClickOnClue(chosenObject);
                    ClickOnDoor(chosenObject);
                    ClickOnTool(chosenObject);
                    ClickOnObstacle(chosenObject);
                }
            }
        }
    }

    public void SetClickOnObject(bool canClick)
    {
        this.canClickOnObject = canClick;
    }

    private void ClickOnMoveableObject(GameObject chosenObject)
    {
        if (chosenObject.CompareTag("MoveableObject"))
        {
            MoveObject moveObject = chosenObject.GetComponent<MoveObject>();
            moveObject.Move();
        }
    }

    private void ClickOnObstacle(GameObject chosenObject)
    {
        if (chosenObject.CompareTag("Obstacle"))
        {
            Unlock unlock = null;
            Information information = chosenObject.GetComponent<Information>();
            if (chosenObject.GetComponent<UnlockByTool>() != null)
            {
                unlock = chosenObject.GetComponent<UnlockByTool>();
            }
            else if (chosenObject.GetComponent<UnlockByPadlockCode>() != null)
            {
                unlock = chosenObject.GetComponent<UnlockByPadlockCode>();
            }
            
            unlock.TryToUnlock();
            information.ShowInformation();
            VictoryHandler(unlock.IsLocked(), chosenObject.name);
        }
    }

    private void VictoryHandler(bool isLocked, string chosenObjectName)
    {
        if (!isLocked && chosenObjectName == "Crates")
        {
            Victory.Invoke();
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

}