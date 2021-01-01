using UnityEngine;

public class IzzySystem : MonoBehaviour
{
    Transform player;
    Interact interact;

    void Update()
    {
        if (!player)
            player = EntitySet.VoidPlayers.Elements[0].transform;

        if (!interact)
            interact = EntitySet.Interacts.Elements[0];

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

                izzy.animator.SetTrigger("sleepHurt");
                interactPoint.update = false;
                interactPoint.interactable = false;

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
                var lenLimit = interactPoint.distance * 2.5f;
                if (!conversation.once || len > lenLimit)
                {
                    if (len > lenLimit)
                        conversation.stop = true;

                    interactPoint.update = true;
                    izzy.state = Izzy.State.Talking;
                }
            }
        }
    }
}