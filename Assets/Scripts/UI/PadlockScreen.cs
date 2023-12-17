using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PadlockScreen : MonoBehaviour
{
    private bool currentlyInProcess;
    private Clicker clicker;
    private GameObject buttonsUI;
    private GameObject instructionsUI;
    private GameObject hintsUI;
    private GameObject firstPersonCamera;
    private PlayerMove playerMove;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMove>();
        currentlyInProcess = false;
        firstPersonCamera = GameObject.Find("First Person Camera");
        buttonsUI = GameObject.Find("Buttons");
        instructionsUI = GameObject.Find("Instructions");
        hintsUI = GameObject.Find("Hints");
        GameObject clickerObject = GameObject.Find("Clicker");
        clicker = clickerObject.GetComponent<Clicker>();
        buttonsUI.SetActive(false);
        instructionsUI.SetActive(false);
        hintsUI.SetActive(false);
    }

    public void SetProcessStatus(bool status)
    {
        this.currentlyInProcess = status;
    }
    public void EnterPadlockScreen()
    {
        // Sert à la gestion de pause. Si le jeu est mis en pause pendant qu'on n'essaye pas de débloquer,
        // on ne veut pas que cette affichage apparaît après la pause
        if (currentlyInProcess)
        {
            firstPersonCamera.SetActive(false);
            clicker.SetClickOnObject(false);
            buttonsUI.SetActive(true);
            instructionsUI.SetActive(true);
            hintsUI.SetActive(true);
            playerMove.SetMovementStatus(false);
        }
    }
    public void LeavePadlockScreen()
    {
        if (currentlyInProcess)
        {
            firstPersonCamera.SetActive(true);
            clicker.SetClickOnObject(true);
            buttonsUI.SetActive(false);
            instructionsUI.SetActive(false);
            hintsUI.SetActive(false);
            playerMove.SetMovementStatus(true);
        }
    }

    public void Cancel()
    {
        LeavePadlockScreen();
        SetProcessStatus(false);
    }
}
