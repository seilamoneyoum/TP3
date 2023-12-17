using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using System.Linq;
using System.Runtime.CompilerServices;

public class UnlockByPadlockCode : Unlock
{
    [SerializeField] private string unsuccessfulMessage;
    [SerializeField] private string gainedObjectAfterUnlock;  
    private int currentIndex;
    private PadlockScreen padlockScreen;
    private TextMeshProUGUI firstNumberText;
    private TextMeshProUGUI secondNumberText;
    private TextMeshProUGUI thirdNumberText;
    private TextMeshProUGUI fourthNumberText;

    // Référence de boutons: https://learn.unity.com/tutorial/creating-ui-buttons#5f7d06d3edbc2a0023e9e713
    private void Awake()
    {
        currentIndex = 0;
        GameObject firstNumber = GameObject.Find("IndexButton (0)");
        GameObject secondNumber = GameObject.Find("IndexButton (1)");
        GameObject thirdNumber = GameObject.Find("IndexButton (2)");
        GameObject fourthNumber = GameObject.Find("IndexButton (3)");
        GameObject padlockScreenObject = GameObject.Find("PadlockScreen");
        firstNumberText = firstNumber.GetComponentInChildren<TextMeshProUGUI>();
        secondNumberText = secondNumber.GetComponentInChildren<TextMeshProUGUI>();
        thirdNumberText = thirdNumber.GetComponentInChildren<TextMeshProUGUI>();
        fourthNumberText = fourthNumber.GetComponentInChildren<TextMeshProUGUI>();
        padlockScreen = padlockScreenObject.GetComponent<PadlockScreen>();
    }

   
    public override void TryToUnlock()
    {
        if (IsLocked())
        {
            padlockScreen.SetProcessStatus(true);
            padlockScreen.EnterPadlockScreen();
        }
    }

    public void SetCurrentIndex(int index)
    {
        currentIndex = index;
    }

    public void SetCode(int number)
    {
        switch (currentIndex)
        {
            case 0:
                firstNumberText.text = number.ToString();
                break;
            case 1:
                secondNumberText.text = number.ToString();
                break;
            case 2:
                thirdNumberText.text = number.ToString();
                break;
            case 3:
                fourthNumberText.text = number.ToString();
                break;
        }
    }

    public void Validate()
    {
        
        string codeAsString = firstNumberText.text + secondNumberText.text + thirdNumberText.text + fourthNumberText.text;
        if (codeAsString == requirementToUnlock)
        {
            padlockScreen.Cancel();
            SuccessfulUnlock();
            StartCoroutine(WaitForSoundToPlay());
            // Pour faire "sortir" l'objet hors de là
            GameObject gainedObject = GameObject.Find(gainedObjectAfterUnlock);
            Move moveObjectComponent = gainedObject.GetComponent<Move>();
            moveObjectComponent.SetPosition();
        }
        else
        {
            text.text = unsuccessfulMessage + "("+ codeAsString+")"; 
        }
    }

    private IEnumerator WaitForSoundToPlay()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
    }




}
