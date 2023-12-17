using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockByTool : Unlock
{
    public override void TryToUnlock()
    {
        if (toolsManager.IsToolAvailable(requirementToUnlock))
        {
            SuccessfulUnlock();
        }
        else
        {
            information.ShowInformation();
        }
    }
}
