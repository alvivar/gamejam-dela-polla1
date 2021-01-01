using UnityEngine;

public class RinSystem : MonoBehaviour
{
    Transform player;
    Interact interact;

    void Update()
    {
        if (!player)
            player = EntitySet.VoidPlayers.Elements[0].transform;

        if (!interact)
            interact = EntitySet.Interacts.Elements[0];

        var rins = EntitySet.GetRin(EntitySet.InteractPointIds, EntitySet.ConversationIds);
        for (int i = 0; i < rins.Length; i++)
        {
            var rin = rins.Elements[i];
            var interactPoint = EntitySet.GetInteractPoint(rin);
            var conversation = EntitySet.GetConversation(rin);

            if (rin.state == Rin.State.Idle)
                continue;

            if (rin.state == rin.lastState)
                continue;

            // Praying

            if (rin.state == Rin.State.Praying)
            {
                rin.lastState = rin.state;

                rin.character.position = rin.prayingLocation.position;
                rin.character.rotation = rin.prayingLocation.rotation;
                rin.animator.SetTrigger("praying");

                interactPoint.update = false;
                interactPoint.interactable = false;
            }

            // AtTheDoor

            if (rin.state == Rin.State.AtTheDoor)
            {
                rin.lastState = rin.state;

                rin.character.position = rin.doorLocation.position;
                rin.character.rotation = rin.doorLocation.rotation;
                rin.animator.SetTrigger("idle");

                interactPoint.update = true;
                interactPoint.interactable = true;

                rin.state = Rin.State.Talking;
            }

            // Start the conversation

            if (rin.state == Rin.State.Talking)
            {
                if (interactPoint.clicked > 0)
                {
                    interactPoint.clicked = 0;

                    // No interaction during the conversation
                    interactPoint.update = false;
                    interact.show = false;
                    conversation.once = true;

                    rin.state = Rin.State.WaitingConversation;
                }
            }

            // Wait until the dialog ends

            if (rin.state == Rin.State.WaitingConversation)
            {
                var len = Vector3.Distance(player.position, interactPoint.transform.position);
                var lenLimit = interactPoint.distance * 2.5f;
                if (!conversation.once || len > lenLimit)
                {
                    if (len > lenLimit)
                        conversation.stop = true;

                    interactPoint.update = true;
                    rin.state = Rin.State.Talking;
                }
            }
        }
    }
}