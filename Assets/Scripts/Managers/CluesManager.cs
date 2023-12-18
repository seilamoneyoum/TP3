using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CluesManager : MonoBehaviour
{
    private static CluesManager instance = null;
    public static CluesManager Instance { get { return instance; } }

    private const int NB_TOTAL_CLUES = 3;
    private List<string> clues = new List<string>();
    private Text nbCluesText;
    void Awake()
    {
        Debug.Log("Before :" + clues.Count);
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        Debug.Log("After :" + clues.Count);

    }

    public void AddClue(GameObject gameObject)
    {
        if (!clues.Contains(gameObject.name))
        {
            clues.Add(gameObject.name);
            nbCluesText = GameObject.Find("NbCluesText").GetComponent<Text>();
            nbCluesText.text = clues.Count.ToString() + "/" + NB_TOTAL_CLUES;
        }
    }

    public bool IsClueAvailable(string name)
    {
        foreach (string clue in clues)
        {
            if (clue.Equals(name)) return true;
        }
        return false;
    }

}
