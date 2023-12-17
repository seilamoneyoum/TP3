using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue : ClickableObject
{
    private CluesManager cluesManager;
    private Information information;
    private CollectEffect collectEffect;
    public override void OnClick()
    {
        collectEffect.AfterCollect();
        information.ShowInformation();
        cluesManager.AddClue(gameObject);
    }
    void Start()
    {
        cluesManager = finder.GetCluesManager();
        information = GetComponent<Information>();
        collectEffect = GetComponent<CollectEffect>();
    }

}
