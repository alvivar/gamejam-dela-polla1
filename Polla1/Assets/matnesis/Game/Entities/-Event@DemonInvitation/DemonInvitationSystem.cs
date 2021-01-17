using UnityEngine;

public class DemonInvitationSystem : MonoBehaviour
{
    public ConversationSentence[] sentences;

    Interact interact;
    Conversation lastConversation;
    int conversationIndex;

    bool touched = false;

    Arrayx<DemonOf> alreadyTalked = Arrayx<DemonOf>.New(5);

    void Update()
    {
        if (!interact)
            interact = EntitySet.Interacts.Elements[0];

        var demonInvitations = EntitySet.DemonInvitations;
        for (int i = 0; i < demonInvitations.Length; i++)
        {
            var demonInvitation = demonInvitations.Elements[i];

            if (demonInvitation.state == DemonInvitation.State.Idle)
                continue;

            if (demonInvitation.state == demonInvitation.lastState)
                continue;

            if (demonInvitation.state == DemonInvitation.State.EnableDemons)
            {
                demonInvitation.lastState = demonInvitation.state;

                var demonOfs = EntitySet.GetDemonOf(EntitySet.DemonOfIds);
                for (int j = 0; j < demonOfs.Length; j++)
                {
                    var demonOf = demonOfs.Elements[j];

                    demonOf.show = false;
                    demonOf.rigidBody.isKinematic = true;
                    demonOf.collidr.enabled = false;
                    demonOf.render.enabled = false;
                    demonOf.transform.position = demonInvitation.cabinPositions[j].transform.position;
                }

                EnableDemons();

                demonInvitation.state = DemonInvitation.State.OneAtTheTimeConversation;
            }

            if (demonInvitation.state == DemonInvitation.State.OneAtTheTimeConversation)
            {
                var demonOfs = EntitySet.GetDemonOf(EntitySet.DemonOfIds, EntitySet.InteractPointIds, EntitySet.ConversationIds);
                for (int j = 0; j < demonOfs.Length; j++)
                {
                    var demonOf = demonOfs.Elements[j];
                    var interactPoint = EntitySet.GetInteractPoint(demonOf);
                    var conversation = EntitySet.GetConversation(demonOf);

                    if (alreadyTalked.Contains(demonOf))
                        continue;

                    // They click over someone

                    if (interactPoint.clicked > 0)
                    {
                        interactPoint.clicked = 0;

                        // Just one at the time

                        alreadyTalked.Add(demonOf);

                        // Hide again

                        demonOf.show = false;

                        // First click

                        if (!touched)
                        {
                            touched = true;
                            for (int k = 0; k < demonOfs.Length; k++)
                                demonOfs.Elements[k].touched = true;
                        }

                        // No interaction during the conversation

                        interactPoint.update = false;
                        interactPoint.interactable = false;
                        interactPoint.enabled = false;
                        interact.show = false;

                        // This particular conversation

                        lastConversation = conversation;
                        conversation.sentences = new ConversationSentence[]
                        {
                            sentences[conversationIndex++]
                        };

                        conversation.once = true;
                        demonInvitation.state = DemonInvitation.State.WaitingConversation;
                        break;
                    }
                }

                // @hardcoded Have we already talked with all the 5 animals?
                // Let's hide.

                if (alreadyTalked.Length >= 5)
                    demonInvitation.state = DemonInvitation.State.UntilLater;
            }

            if (demonInvitation.state == DemonInvitation.State.WaitingConversation)
            {
                if (!lastConversation.once)
                {
                    EnableDemons();
                    demonInvitation.state = DemonInvitation.State.OneAtTheTimeConversation;
                }
            }

            if (demonInvitation.state == DemonInvitation.State.UntilLater)
            {
                // @todo Something special here
            }
        }
    }

    public void EnableDemons()
    {
        var demonOfs = EntitySet.GetDemonOf(EntitySet.DemonOfIds, EntitySet.InteractPointIds, EntitySet.ConversationIds);
        for (int j = 0; j < demonOfs.Length; j++)
        {
            var demonOf = demonOfs.Elements[j];
            var interactPoint = EntitySet.GetInteractPoint(demonOf);

            if (alreadyTalked.Contains(demonOf))
                continue;

            demonOf.show = true;
            demonOf.touched = true;
            interactPoint.update = true;
            interactPoint.interactable = true;
            interactPoint.clicked = 0;
        }
    }
}