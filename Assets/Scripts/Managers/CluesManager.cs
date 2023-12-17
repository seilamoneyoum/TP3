using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CluesManager : MonoBehaviour
{
    private static CluesManager instance = null;
    public static CluesManager Instance { get { return instance; } }

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private const int NB_TOTAL_CLUES = 3;
    private List<GameObject> clues = new List<GameObject>();
    Text nbCluesText;

    public void AddClue(GameObject gameObject)
    {
        if (!clues.Contains(gameObject))
        {
            clues.Add(gameObject);
            nbCluesText = GameObject.Find("NbCluesText").GetComponent<Text>();
            nbCluesText.text = clues.Count.ToString() + "/" + NB_TOTAL_CLUES;
        }
    }

    public bool IsClueAvailable(string name)
    {
        foreach (GameObject clue in clues)
        {
            if (clue.name.Equals(name)) return true;
        }
        return false;
    }

}
