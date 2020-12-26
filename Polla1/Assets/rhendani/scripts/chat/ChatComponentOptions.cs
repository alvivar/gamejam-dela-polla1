using UnityEngine;
using UnityEngine.UI;
using Fluent;
using TMPro;

public abstract class ChatComponentOptions : FluentScript
{
    //[Space]
    //public CreateDialogueProperties charName;
    [ShowInfo("NAME PANEL")]
    public TextMeshProUGUI nameText;
    public RectTransform namePanel;
    [ShowInfo("PANEL")]
    [Range(170,450)]
    public float panelHeight = 300;
    public RectTransform wholePanel;
    public TextMeshProUGUI response;
    public Button nextButton;
    [ShowInfo("OPTIONS PANEL")]
    [Range(-60,90)]
    public float optionsPosition = 30;
    [Range(30,50)]
    public float optionsHeight = 30;
    [Range(14,30)]
    public float optionsFontSize = 20;
    public RectTransform optionsPanel;
    //public RectTransform optionsItemPrefab;
    [ShowInfo("MORE")]
    //public CharacterMovement movement;
    //public ObjectButton button;
    public bool enableRealTime;

    [HideInInspector]
    //public Vector2 panelStartPos;
    string name;
    float namePanelLenght = 300;

    private void Awake()
    {

        //panelStartPos = wholePanel.pivot;
        //name = charName.name;
        //namePanelLenght = charName.namePanelLenght;

        //optionsItemPrefab.transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = optionsFontSize;
        optionsPanel.GetComponent<GridLayoutGroup>().cellSize = new Vector2(350, optionsHeight);

        GetComponent<OptionsPresenter>().DialogUI = wholePanel;
        //GetComponent<OptionsPresenter>().OptionItemUI = optionsItemPrefab.gameObject;
        GetComponent<OptionsPresenter>().OptionsPanel = optionsPanel.gameObject;
        GetComponent<WriteHandler>().TextUI = response;
        GetComponent<WriteHandler>().Button = nextButton;
    }

    public override void OnStart()
    {
        // SET EVERYTHING
        Vector3 pos = optionsPanel.anchoredPosition;
        optionsPanel.anchoredPosition = new Vector3(pos.x, optionsPosition, pos.z);
        namePanel.sizeDelta = new Vector2(namePanelLenght, namePanel.sizeDelta.y);
        wholePanel.sizeDelta = new Vector2(wholePanel.sizeDelta.x, panelHeight);
        nameText.text = name;
        //

        //movement.enabled = false;
        //if (button != null && !button.locked)
        //{
        //    button.isPressed = true;
        //    button.locked = true;
        //}

        base.OnStart();
    }

    public override void OnFinish()
    {
        wholePanel.gameObject.SetActive(false);
        //movement.enabled = true;

        //if (button != null)
        //{
        //    button.isPressed = false;
        //    button.locked = false;
        //}
    }

    void Update()
    {
        if (enableRealTime)
        {
            // SET EVERYTHING
            Vector3 pos = optionsPanel.anchoredPosition;
            optionsPanel.anchoredPosition = new Vector3(pos.x, optionsPosition, pos.z);
            namePanel.sizeDelta = new Vector2(namePanelLenght, namePanel.sizeDelta.y);
            wholePanel.sizeDelta = new Vector2(wholePanel.sizeDelta.x, panelHeight);
            nameText.text = name;
            //
        }
    }

}
