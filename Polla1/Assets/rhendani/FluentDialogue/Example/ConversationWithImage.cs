using UnityEngine;
using UnityEngine.UI;
using Fluent;

public abstract class ConversationWithImage : MyFluentDialogue
{
    public GameObject SourceObject;
    public Sprite CharacterHeadSprite;

    public override void OnStart()
    {
        SetNPCHead();
        base.OnStart();
    }

    private void SetNPCHead()
    {
        OptionsPresenter optionsPresenter = GetComponent<OptionsPresenter>();
        if (optionsPresenter.DialogUI.transform.Find("NPCHeadImage") != null)
        {
            Image image = optionsPresenter.DialogUI.transform.Find("NPCHeadImage").GetComponent<Image>();
            image.sprite = CharacterHeadSprite;
            //return;
        }
        SourceObject.GetComponent<Image>().sprite = CharacterHeadSprite;
    }
}
