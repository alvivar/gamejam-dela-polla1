using UnityEngine;
using Fluent;

public class ConversationLel : MyFluentDialogue
{
    [ShowInfo("Something")]
    public bool no;

    public override FluentNode Create()
    {
        return
            Yell("Anyone can yell!") * Yell("Shut the hell up");
    }

}
