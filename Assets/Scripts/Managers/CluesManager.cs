using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CluesManager : MonoBehaviour
{
    private const int NB_TOTAL_CLUES = 8;
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
}
