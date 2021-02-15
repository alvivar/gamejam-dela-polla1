using UnityEngine;

public class WatchingTheSeaSystem : MonoBehaviour
{
    public ConversationSentence[] conversation1;
    public ConversationSentence[] conversation2;
    public ConversationSentence[] conversation3;
    public ConversationSentence[] conversation4;

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

        var watchingTheSeas = EntitySet.GetWatchingTheSea(EntitySet.InteractPointIds, EntitySet.ConversationIds);
        for (int i = 0; i < watchingTheSeas.Length; i++)
        {
            var watchingTheSea = watchingTheSeas.Elements[i];
            var interactPoint = EntitySet.GetInteractPoint(watchingTheSea);
            var conversation = EntitySet.GetConversation(watchingTheSea);

            if (watchingTheSea.state == WatchingTheSea.State.Idle)
                continue;

            // Start the conversation

            if (watchingTheSea.state == WatchingTheSea.State.CanDialog)
            {
                if (interactPoint.clicked > 0)
                {
                    interactPoint.clicked = 0;

                    // No interaction during the conversation
                    interactPoint.update = false;
                    interact.show = false;
                    conversation.once = true;

                    watchingTheSea.state = WatchingTheSea.State.Talking;
                }
            }

            // Wait until the dialog ends

            if (watchingTheSea.state == WatchingTheSea.State.Talking)
            {
                var len = Vector3.Distance(player.position, interactPoint.transform.position);
                var lenLimit = interactPoint.distance * 3f;
                if (!conversation.once || len > lenLimit)
                {
                    if (len > lenLimit)
                        conversation.stop = true;

                    interactPoint.update = true;
                    watchingTheSea.state = WatchingTheSea.State.CanDialog;
                }
            }
        }
    }
}