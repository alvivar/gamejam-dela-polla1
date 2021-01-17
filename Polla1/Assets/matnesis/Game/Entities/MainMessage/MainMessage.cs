using TMPro;
using UnityEngine;
using UnityEngine.UI;

// !Gigas
public class MainMessage : MonoBehaviour
{
    [Header("State")]
    public bool showMain = false;
    public bool showConversation = false;
    public bool showQuestion = false;

    [Header("Config")]
    public float mainDamp = 10;
    public float conversationDamp = 10;

    [Header("Info")]
    public int yesPressed = 0;
    public int noPressed = 0;

    [Header("Children References")]
    public Canvas canvas;
    public TextMeshProUGUI main;
    public TextMeshProUGUI conversation;
    public Image background;
    public Image conversationBackground;
    public Image questionBackground;
    public TextMeshProUGUI question;
    public TextMeshProUGUI yesAnswer;
    public TextMeshProUGUI noAnswer;

    private void OnEnable()
    {
        EntitySet.AddMainMessage(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveMainMessage(this);
    }
}