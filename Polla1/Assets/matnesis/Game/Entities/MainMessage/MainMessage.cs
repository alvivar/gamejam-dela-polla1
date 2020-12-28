using TMPro;
using UnityEngine;
using UnityEngine.UI;

// !Gigas
public class MainMessage : MonoBehaviour
{
    public bool showMain = false;
    public bool showConversation = false;
    public bool showQuestion = false;

    public float mainDamp = 10;
    public float conversationDamp = 10;

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