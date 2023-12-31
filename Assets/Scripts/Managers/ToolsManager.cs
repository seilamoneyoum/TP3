using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolsManager : MonoBehaviour
{
    private const int NB_TOTAL_TOOLS = 3;
    private List<string> tools = new List<string>();
    private Text nbToolsText;

    private void Start()
    {
        nbToolsText = GameObject.Find("NbToolsText").GetComponent<Text>();
        nbToolsText.text = tools.Count.ToString() + "/" + NB_TOTAL_TOOLS;
    }


    public void AddTool(GameObject gameObject)
    {
        if (!tools.Contains(gameObject.name))
        {
            tools.Add(gameObject.name);
            nbToolsText.text = tools.Count.ToString() + "/" + NB_TOTAL_TOOLS;
        }
    }

    public bool IsToolAvailable(string name)
    {
        foreach (string tool in tools)
        {
            if (tool.Equals(name)) return true;
        }
        return false;
    }

}
