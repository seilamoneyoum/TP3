using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Obstacle : ClickableObject
{
    private Unlock unlock;
    private Information information;
    private GameManager gameManager;
    private TimeManager timeManager;
    private PlayerMove playerMove;

    public override void OnClick()
    {
        unlock.TryToUnlock();
        information.ShowInformation();
        VictoryHandler(unlock.IsLocked(), gameObject.name);
    }

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMove>();
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
            playerMove.SetMovementStatus(false);
            timeManager.SetTimeResume(false);
            gameManager.LoadScene(10, 2);
        }
    }

}
