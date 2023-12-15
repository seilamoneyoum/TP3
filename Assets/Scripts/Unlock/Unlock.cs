using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Unlock : MonoBehaviour
{
    [SerializeField] protected string requiredObjectToUnlock = "";
    [SerializeField] protected string successfulUnlockMessage = "";
    private bool isLocked;
    private Finder finder;
    protected ToolsManager toolsManager;
    protected ProgressManager progressManager;
    protected SoundManager soundManager;
    protected Text text;
    protected Information information;
    protected AudioSource audioSource;

    private void Start()
    {
        isLocked = true;
        GameObject finderObject = GameObject.Find("Finder");
        finder = finderObject.GetComponent<Finder>();
        toolsManager = finder.GetToolsManager();
        progressManager = finder.GetProgressManager();
        soundManager = finder.GetSoundManager();
        text = finder.GetMessageText();
        information = gameObject.GetComponent<Information>();
        audioSource = GetComponent<AudioSource>();

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
