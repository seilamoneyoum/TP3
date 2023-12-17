using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolsManager : MonoBehaviour
{
    private const int NB_TOTAL_TOOLS = 3;
    private List<GameObject> tools = new List<GameObject>();
    private Text nbToolsText;

    public void AddTool(GameObject gameObject)
    {
        if (!tools.Contains(gameObject))
        {
            tools.Add(gameObject);
            nbToolsText = GameObject.Find("NbToolsText").GetComponent<Text>();
            nbToolsText.text = tools.Count.ToString() + "/" + NB_TOTAL_TOOLS;
        }
    }

    public bool IsToolAvailable(string name)
    {
        foreach (GameObject tool in tools)
        {
            if (tool.name.Equals(name)) return true;
        }
        return false;
    }

}
