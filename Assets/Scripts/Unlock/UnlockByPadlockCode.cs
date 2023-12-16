using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class UnlockByPadlockCode : Unlock
{
    [SerializeField] private string unsuccessfulMessage;
    [SerializeField] private string gainedObjectAfterUnlock;  
    private TextMeshProUGUI firstNumberText;
    private TextMeshProUGUI secondNumberText;
    private TextMeshProUGUI thirdNumberText;
    private TextMeshProUGUI fourthNumberText;
    private int currentIndex;
    private bool currentlyInProcess;
    GameObject padlockScreen;
    GameObject firstPersonCamera;

    // Référence de boutons: https://learn.unity.com/tutorial/creating-ui-buttons#5f7d06d3edbc2a0023e9e713
    private void Awake()
    {
        currentIndex = 0;
        firstPersonCamera = GameObject.Find("First Person Camera");
        padlockScreen = GameObject.Find("PadlockScreen");
        GameObject firstNumber = GameObject.Find("IndexButton (0)");
        GameObject secondNumber = GameObject.Find("IndexButton (1)");
        GameObject thirdNumber = GameObject.Find("IndexButton (2)");
        GameObject fourthNumber = GameObject.Find("IndexButton (3)");
        firstNumberText = firstNumber.GetComponentInChildren<TextMeshProUGUI>();
        secondNumberText = secondNumber.GetComponentInChildren<TextMeshProUGUI>();
        thirdNumberText = thirdNumber.GetComponentInChildren<TextMeshProUGUI>();
        fourthNumberText = fourthNumber.GetComponentInChildren<TextMeshProUGUI>();
        padlockScreen.SetActive(false);
    }

   
    public override void TryToUnlock()
    {
        if (IsLocked())
        {
            currentlyInProcess = true;
            EnterPadlockScreen();
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
           
            LeavePadlockScreen();
            currentlyInProcess = false;
            // Pour faire "sortir" l'objet hors de là
            GameObject gainedObject = GameObject.Find(gainedObjectAfterUnlock);
            Vector3 newPosition = gainedObject.transform.position;
            newPosition.y *= 3;
            gainedObject.transform.position = newPosition;
        }
        else
        {
            text.text = unsuccessfulMessage + "("+ codeAsString+")"; 
        }
    }

    public void Cancel()
    {
        LeavePadlockScreen();
        currentlyInProcess = false;
    }

    public void EnterPadlockScreen()
    {
        // Sert à la gestion de pause. Si le jeu est mis en pause pendant qu'on n'essaye pas de débloquer,
        // on ne veut pas que cette affichage apparaît après la pause
        if (currentlyInProcess) 
        {
            firstPersonCamera.SetActive(false);
            clicker.SetClickOnObject(false);
            padlockScreen.SetActive(true);
        }
    }

    public void LeavePadlockScreen()
    {
        if (currentlyInProcess)
        {
            firstPersonCamera.SetActive(true);
            clicker.SetClickOnObject(true);
            padlockScreen.SetActive(false);
        }
    }
}
