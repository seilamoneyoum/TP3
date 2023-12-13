using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleManager : MonoBehaviour
{
    private const int NB_TOTAL_KEYS = 5;
    private const int NB_TOTAL_CLUES = 8;
    private List<GameObject> keys = new List<GameObject>();
    private List<GameObject> clues = new List<GameObject>();
    Text nbCluesText;
    Text nbKeysText;

    public void AddKey(GameObject gameObject)
    {
        keys.Add(gameObject);
        nbKeysText = GameObject.Find("NbKeysText").GetComponent<Text>();
        nbKeysText.text = keys.Count.ToString() + "/" + NB_TOTAL_KEYS;
    }

    public void AddClue(GameObject gameObject)
    {
        clues.Add(gameObject);
        nbCluesText = GameObject.Find("NbCluesText").GetComponent<Text>();
        nbCluesText.text = clues.Count.ToString() + "/" + NB_TOTAL_CLUES;
    }

    public bool IsKeyAvailable(string name)
    {
        foreach (GameObject key in keys)
        {
            if (key.name.Equals(name)) return true;
        }
        return false;
    }

}
