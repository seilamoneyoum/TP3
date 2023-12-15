using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockByTool : Unlock
{
    public override void TryToUnlock()
    {
        if (toolsManager.IsToolAvailable(requiredObjectToUnlock))
        {
            information.SetNewInformation(successfulUnlockMessage);
            SetLockedStatus(false);
            audioSource.clip = soundManager.RemoveWedgeClip;
            audioSource.Play();
            progressManager.AddUnlockProgress();
        }
        else
        {
            information.ShowInformation();
        }
    }
}
