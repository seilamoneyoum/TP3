using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AftermathInformationHandler : MonoBehaviour
{
    private const string CLUE_NOT_FOUND_MESSAGE = "Cet indice n'est pas trouvé"; 
    [SerializeField] private string clueCollected;
    [SerializeField] private string information;
    private CluesManager cluesManager;
    private TextMeshProUGUI text;
    private void OnEnable()
    {
        text = GetComponent<TextMeshProUGUI>();
        GameObject cluesManagerObject = GameObject.Find("CluesManager");
        cluesManager = cluesManagerObject.GetComponent<CluesManager>();
    }

    private void Start()
    {
        if (cluesManager.IsClueAvailable(clueCollected))
        {
            text.text = information;
        }
        else
        {
            text.text = CLUE_NOT_FOUND_MESSAGE;
        }
    }
}
