using Fluent;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This example shows how to inherit from Conversation and add a npc image to the options presenter
/// </summary>
public class ConversationCONFIG : ChatComponentOptions
{

    public override FluentNode Create()
    {
        return
        Show()
        *
        Write("how how how how how how how how how how how how")
        *
        Options(
            Option("did you do it? did you do it? did you do it? did you do it?")
                    * Write("Yes! Yes! Yes! Yes! Yes! Yes! Yes! Yes! Yes! Yes! Yes! Yes!").WaitForButton()
                    * Write("I AM EXAUSTED I AM EXAUSTED I AM EXAUSTED I AM EXAUSTED")
            *
            Option("i ate cake")
                    * Write("Yes! Yes! Yes! Yes! Yes! Yes! Yes! Yes! Yes! Yes! Yes! Yes!").WaitForButton()
                    * Write("I AM EXAUSTED I AM EXAUSTED I AM EXAUSTED I AM EXAUSTED").WaitForButton()
                    * Pause(0.1f)
                    * Hide()
                    * End()
            );
    }
    void OnFinish() { }

}
