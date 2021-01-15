using UnityEngine;

public class IzzySystem : MonoBehaviour
{
    Transform player;
    Interact interact;
    EyeOfCreator eyeOfCreator;

    void Update()
    {
        if (!player)
            player = EntitySet.VoidCams.Elements[0].transform;

        if (!interact)
            interact = EntitySet.Interacts.Elements[0];

        if (!eyeOfCreator)
            eyeOfCreator = EntitySet.EyeOfCreators.Elements[0];

        var izzys = EntitySet.Izzys;
        for (int i = 0; i < izzys.Length; i++)
        {
            var izzy = izzys.Elements[i];
            var interactPoint = EntitySet.GetInteractPoint(izzy);
            var conversation = EntitySet.GetConversation(izzy);

            if (izzy.state == Izzy.State.Idle)
                continue;

            if (izzy.state == izzy.lastState)
                continue;

            // Praying

            if (izzy.state == Izzy.State.Sleeping)
            {
                izzy.lastState = izzy.state;

                izzy.character.transform.position = izzy.sleepingPos.transform.position;
                izzy.character.transform.rotation = izzy.sleepingPos.transform.rotation;

                izzy.animator.SetTrigger("sleepHurt");
                interactPoint.update = true;
                interactPoint.interactable = true;

                izzy.state = Izzy.State.Talking;
            }

            // Start the conversation

            if (izzy.state == Izzy.State.Talking)
            {
                if (interactPoint.clicked > 0)
                {
                    interactPoint.clicked = 0;

                    // No interaction during the conversation
                    interactPoint.update = false;
                    interact.show = false;
                    conversation.once = true;

                    izzy.state = Izzy.State.WaitingConversation;
                }
            }

            // Wait until the dialog ends

            if (izzy.state == Izzy.State.WaitingConversation)
            {
                var len = Vector3.Distance(player.position, interactPoint.transform.position);
                var lenLimit = interactPoint.distance * 5f;
                if (!conversation.once || len > lenLimit)
                {
                    if (len > lenLimit)
                    {
                        conversation.stop = true;

                        eyeOfCreator.New("She can't talk");
                    }

                    interactPoint.update = true;
                    izzy.state = Izzy.State.Talking;
                }
            }
        }
    }
}