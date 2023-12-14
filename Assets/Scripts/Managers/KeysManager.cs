using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeysManager : MonoBehaviour
{
    private const int NB_TOTAL_KEYS = 5;
    private List<GameObject> keys = new List<GameObject>();
    Text nbKeysText;

    public void AddKey(GameObject gameObject)
    {
        if (!keys.Contains(gameObject))
        {
            keys.Add(gameObject);
            nbKeysText = GameObject.Find("NbKeysText").GetComponent<Text>();
            nbKeysText.text = keys.Count.ToString() + "/" + NB_TOTAL_KEYS;
        }
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
