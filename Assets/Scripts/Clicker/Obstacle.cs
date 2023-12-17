using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Obstacle : ClickableObject
{
    [SerializeField] private UnityEvent Victory;
    private Unlock unlock;
    private Information information;
    private GameManager gameManager;
    private TimeManager timeManager;
    public override void OnClick()
    {
        unlock.TryToUnlock();
        information.ShowInformation();
        VictoryHandler(unlock.IsLocked(), gameObject.name);
    }

    void Start()
    {
        gameManager = finder.GetGameManager();
        timeManager = finder.GetTimeManager();
        information = GetComponent<Information>();
        if (GetComponent<UnlockByTool>() != null)
        {
            unlock = GetComponent<UnlockByTool>();
        }
        else if (GetComponent<UnlockByPadlockCode>() != null)
        {
            unlock = GetComponent<UnlockByPadlockCode>();
        }
    }

    private void VictoryHandler(bool isLocked, string chosenObjectName)
    {
        if (!isLocked && chosenObjectName == "Crates")
        {
            timeManager.SetTimeResume(false);
            gameManager.LoadScene(10, 2);
        }
    }

}
