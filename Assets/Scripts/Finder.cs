using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finder : MonoBehaviour
{
    private Text messageText;
    private SoundManager soundManager;
    private GameManager gameManager;
    private TimeManager timeManager;
    private ToolsManager toolsManager;
    private CluesManager cluesManager;
    private ProgressManager progressManager;
    private Clicker clicker;

    void Awake()
    {
        GameObject messageTextObject = GameObject.Find("MessageText");
        messageText = messageTextObject.GetComponent<Text>();

        GameObject soundManagerObject = GameObject.Find("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();

        GameObject toolsManagerObject = GameObject.Find("ToolsManager");
        toolsManager = toolsManagerObject.GetComponent<ToolsManager>();

        GameObject gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();

        GameObject timeManagerObject = GameObject.Find("TimeManager");
        timeManager = timeManagerObject.GetComponent<TimeManager>();

        GameObject cluesManagerObject = GameObject.Find("CluesManager");
        cluesManager = cluesManagerObject.GetComponent<CluesManager>();

        GameObject progressManagerObject = GameObject.Find("ProgressManager");
        progressManager = progressManagerObject.GetComponent<ProgressManager>();

        GameObject clickerObject = GameObject.Find("Clicker");
        clicker = clickerObject.GetComponent<Clicker>();
    }

    public Clicker GetClicker()
    {
        return clicker;
    }

    public Text GetMessageText()
    {
        return messageText;
    }

    public SoundManager GetSoundManager()
    {
        return soundManager;
    }

    public GameManager GetGameManager()
    {
        return gameManager;
    }

    public TimeManager GetTimeManager()
    {
        return timeManager;
    }

    public ToolsManager GetToolsManager()
    {
        return toolsManager;
    }

    public CluesManager GetCluesManager()
    {
        return cluesManager;
    }

    public ProgressManager GetProgressManager()
    {
        return progressManager;
    }

}
