using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Unlock : MonoBehaviour
{
    [SerializeField] protected string requirementToUnlock = "";
    [SerializeField] protected string successfulUnlockMessage = "";
    [SerializeField] protected AudioClip audioClip;
    private bool isLocked = true;
    private Finder finder;
    protected ToolsManager toolsManager;
    protected ProgressManager progressManager;
    protected Text text;
    protected Information information;
    protected AudioSource audioSource;

    private void OnEnable()
    {
        GameObject finderObject = GameObject.Find("Finder");
        finder = finderObject.GetComponent<Finder>();
    }

    private void Start()
    {
        toolsManager = finder.GetToolsManager();
        progressManager = finder.GetProgressManager();
        text = finder.GetMessageText();
        information = gameObject.GetComponent<Information>();
        audioSource = GetComponent<AudioSource>();
    }
    protected void SuccessfulUnlock()
    {
        information.SetNewInformation(successfulUnlockMessage);
        SetLockedStatus(false);
        audioSource.clip = audioClip;
        audioSource.Play();
        progressManager.AddUnlockProgress();
    }
    public bool IsLocked()
    {
        return isLocked;
    }

    protected void SetLockedStatus(bool status)
    {
        this.isLocked = status;
    }

    public abstract void TryToUnlock();

}
