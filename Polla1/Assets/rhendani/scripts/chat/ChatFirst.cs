using Fluent;
using UnityEngine;
//using matnesis.TeaTime;


/// <summary>
/// This example shows how to inherit from Conversation and add a npc image to the options presenter
/// </summary>
public class ChatFirst : ChatComponentOptions
{
    //[ShowInfo("OBJECTS")]
    //public CameraCharacter animCam;
    //public Transform targetPoint;
    //public Transform characterPoint;
    //public DoorComponent door;

    public bool finished = false;

    public void SetFinished(bool target)
    {
        finished = target;
    }
    

    //TeaTime teat(bool open) {
    //    return this.tt()
    //                    .Add(0.0f, () => { print("1"); animCam.thisLook = targetPoint; })
    //                    .Add(0.1f, () =>
    //                    {
    //                        door.isOpen = open;
    //                    })
    //                    .Add(1.0f, () =>
    //                    {
    //                        animCam.thisLook = characterPoint;
    //                    })
    //                    .Add(0, () =>
    //                    { 
    //                        print("3");
    //                        wholePanel.localScale = Vector3.one;
    //                        finished = true;
    //                    });
    //}

    public override FluentNode Create()
    {
        return
        Show()
        * Write("Hola buenas mucho gusto, que se le ofrece?")
            * Do(() => {
                finished = false;
            })
        * ContinueWhen(() => finished)
        * Write("Hola buenas mucho gusto, que se le ofrece?")
            * Do(() => {
                finished = false;
            })
        * ContinueWhen(() => finished)
        * Hide()
        * End();
    }

}
