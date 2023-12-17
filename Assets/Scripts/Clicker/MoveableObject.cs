using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : ClickableObject
{
    private Move moveComponent;
    public override void OnClick()
    {
        moveComponent.SetPosition();
    }

    private void Start()
    {
        moveComponent = GetComponent<Move>();
    }
}
