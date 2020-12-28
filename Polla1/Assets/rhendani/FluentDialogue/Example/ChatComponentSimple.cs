using UnityEngine;
using UnityEngine.UI;
using Fluent;
using TMPro;

public abstract class ChatComponentSimple : MyFluentDialogue
{
    public TextMeshProUGUI nameText;
    public string name;
    public float panelHeight = 300;

    public override void OnStart()
    {
        nameText.text = name;
        SetNPCHead();
        base.OnStart();
    }

    private void SetNPCHead()
    {
        /*OptionsPresenter optionsPresenter = GetComponent<OptionsPresenter>();
        if (optionsPresenter.DialogUI.transform.Find("NPCHeadImage") != null)
        {
            Image image = optionsPresenter.DialogUI.transform.Find("NPCHeadImage").GetComponent<Image>();
            image.sprite = CharacterHeadSprite;
            //return;
        }
        SourceObject.GetComponent<Image>().sprite = CharacterHeadSprite;*/
    }
}
