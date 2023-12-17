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
    private AudioSource mainCameraAudioSource;

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

        GameObject mainCameraObject = GameObject.Find("Main Camera");
        mainCameraAudioSource = mainCameraObject.GetComponent<AudioSource>();

    }

    public AudioSource GetMainCameraAudioSource()
    {
        return mainCameraAudioSource;
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

}
