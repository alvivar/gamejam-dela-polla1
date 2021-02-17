using System.Collections.Generic;
using UnityEngine;

public class WatchingTheSeaSystem : MonoBehaviour
{
    [Header("Conversations")]
    public ConversationSentence[] conversation1;
    public ConversationSentence[] conversation2;
    public ConversationSentence[] conversation3;
    public ConversationSentence[] conversation4;
    public ConversationSentence[] conversation5;
    public ConversationSentence[] conversation6;

    [Header("Internal")]
    public Elf elf;

    List<ConversationSentence[]> conversations = new List<ConversationSentence[]>();
    int conversationIndex = 0;

    Transform player;
    Interact interact;
    EyeOfCreator eyeOfCreator;
    MainMessage message;

    void Start()
    {
        conversations.Add(conversation1);
        conversations.Add(conversation2);
        conversations.Add(conversation3);
        conversations.Add(conversation4);
        conversations.Add(conversation5);
        conversations.Add(conversation6);
    }

    void Update()
    {
        if (!player)
            player = EntitySet.VoidCams.Elements[0].transform;

        if (!interact)
            interact = EntitySet.Interacts.Elements[0];

        if (!eyeOfCreator)
            eyeOfCreator = EntitySet.EyeOfCreators.Elements[0];

        if (!message)
            message = EntitySet.MainMessages.Elements[0];

        if (!elf)
            elf = EntitySet.Elfs.Elements[0];

        var watchingTheSeas = EntitySet.GetWatchingTheSea(EntitySet.InteractPointIds, EntitySet.ConversationIds);
        for (int i = 0; i < watchingTheSeas.Length; i++)
        {
            var watchingTheSea = watchingTheSeas.Elements[i];
            var interactPoint = EntitySet.GetInteractPoint(watchingTheSea);
            var conversation = EntitySet.GetConversation(watchingTheSea);

            if (watchingTheSea.state == WatchingTheSea.State.Idle)
                continue;

            if (watchingTheSea.state == watchingTheSea.lastState)
                continue;

            // Start the conversation

            if (watchingTheSea.state == WatchingTheSea.State.CanDialog)
            {
                if (interactPoint.clicked > 0)
                {
                    interactPoint.clicked = 0;

                    // One conversation from the index.
                    if (conversationIndex >= conversations.Count)
                    {
                        message.showQuestion = true;
                        message.question.text = "Would you help me?";

                        message.yesPressed = 0;
                        message.noPressed = 0;

                        watchingTheSea.state = WatchingTheSea.State.AskingForHelp;
                        continue;
                    }

                    conversation.sentences = conversations[conversationIndex];
                    conversationIndex += 1;

                    // Wait to be sad.
                    if (conversationIndex == 4)
                    {
                        this.tt()
                            .Wait(() => conversationIndex == 5)
                            .Add(() =>
                            {
                                message.mainDamp = 15;
                                message.main.text = "";
                                message.showMain = true;
                            })
                            .Add(1, () =>
                            {
                                elf.state = Elf.State.Sad;
                            })
                            .Add(0.2f, () =>
                            {
                                message.mainDamp = 0.1f;
                                message.showMain = false;
                            });
                    }

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

                    watchingTheSea.state = WatchingTheSea.State.CanDialog;

                    this.tt().Add(1f, () => interactPoint.update = true);
                }
            }

            // Asking for help

            if (watchingTheSea.state == WatchingTheSea.State.AskingForHelp)
            {
                watchingTheSea.lastState = watchingTheSea.state;

                this.tt("WatchingTheSea.State.AskingForHelp").Reset().Loop(t =>
                {
                    Debug.Log($"Waiting AskingForHelp at {Time.time}");
                    t.Wait(1);

                    if (message.yesPressed > 0)
                    {
                        Debug.Log($"YES at {Time.time}");
                        t.Break();
                    }
                    else if (message.noPressed > 0)
                    {
                        Debug.Log($"NO at {Time.time}");
                        t.Break();
                    }
                });

            }
        }
    }
}