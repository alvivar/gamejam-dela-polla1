using UnityEngine;

public class WatchingTheSeaSystem : MonoBehaviour
{
    Transform player;
    Interact interact;

    enum Stage { CanDialog, Talking }
    Stage stage = Stage.CanDialog;

    void Update()
    {
        if (!player)
            player = EntitySet.VoidCams.Elements[0].transform;

        if (!interact)
            interact = EntitySet.Interacts.Elements[0];

        var watchingTheSeas = EntitySet.GetWatchingTheSea(EntitySet.InteractPointIds, EntitySet.ConversationIds);
        for (int i = 0; i < watchingTheSeas.Length; i++)
        {
            var watchingTheSea = watchingTheSeas.Elements[i];
            var interactPoint = EntitySet.GetInteractPoint(watchingTheSea);
            var conversation = EntitySet.GetConversation(watchingTheSea);

            // Start the conversation

            if (stage == Stage.CanDialog)
            {
                if (interactPoint.clicked > 0)
                {
                    interactPoint.clicked = 0;

                    // No interaction during the conversation
                    interactPoint.update = false;
                    interact.show = false;
                    conversation.once = true;

                    stage = Stage.Talking;
                }
            }

            // Wait until the dialog ends

            if (stage == Stage.Talking)
            {
                var len = Vector3.Distance(player.position, interactPoint.transform.position);
                var lenLimit = interactPoint.distance * 2.5f;
                if (!conversation.once || len > lenLimit)
                {
                    if (len > lenLimit)
                        conversation.stop = true;

                    interactPoint.update = true;
                    stage = Stage.CanDialog;
                }
            }
        }
    }
}