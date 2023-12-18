using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Clicker : MonoBehaviour
{
    [SerializeField] private UnityEvent Victory;
    [SerializeField] private bool canClickOnObject;
    private const float MAX_DISTANCE = 1.2f;
    private Camera m_Camera;

    // Référence: https://learn.unity.com/tutorial/onmousedown#63566bf3edbc2a0285856b5a

    private void OnEnable()
    {
        m_Camera = Camera.main;
        canClickOnObject = true;
    }

    void Update()
    {
        HandleMouseInput();
    }

    private void HandleMouseInput()
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
                    HandleObjectClick(chosenObject);
                }
            }
        }
    }
    public void SetClickOnObject(bool canClick)
    {
        this.canClickOnObject = canClick;
    }
    private void HandleObjectClick(GameObject chosenObject)
    {
        ClickableObject clickableObject = chosenObject.GetComponent<ClickableObject>();
        if (clickableObject != null)
        {
            clickableObject.OnClick();
        }
    }
}
