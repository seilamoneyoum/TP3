using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class Tool : ClickableObject
{
    private ToolsManager toolsManager;
    private Information information;
    private CollectEffect collectEffect;

    void Start()
    {
        toolsManager = finder.GetToolsManager();
        information = GetComponent<Information>();
        collectEffect = GetComponent<CollectEffect>();
    }
    public override void OnClick()
    {
        Debug.Log("test");
        collectEffect.AfterCollect();
        information.ShowInformation();
        toolsManager.AddTool(gameObject);
    }



}
