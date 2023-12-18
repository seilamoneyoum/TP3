using System.Collections;
using System.Collections.Generic;
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
        collectEffect.Collect();
        information.ShowInformation();
        toolsManager.AddTool(gameObject);
    }
}
