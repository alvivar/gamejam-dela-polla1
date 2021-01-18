using UnityEngine;

public class ConversationSystem : MonoBehaviour
{
    int index = 0;
    float delay = 0;

    MainMessage message;
    Conversation lockedBy;

    bool eToSkip = false;

    void Update()
    {
        if (!message)
            message = EntitySet.MainMessages.Elements[0];

        var conversations = EntitySet.Conversations;
        for (int i = 0; i < conversations.Length; i++)
        {
            var conversation = conversations.Elements[i];

            if (lockedBy != null && lockedBy != conversation)
                continue;

            if (conversation.once)
            {
                lockedBy = conversation;

                if (Input.GetKeyDown(KeyCode.E))
                    eToSkip = true;

                // Have a say

                message.conversation.text = conversation.sentences[index].say;
                message.showConversation = true;

                // Progress through the delays

                if (delay > conversation.sentences[index].delay || eToSkip)
                {
                    eToSkip = false;

                    delay = 0;
                    index += 1;
                }
                else
                {
                    delay += Time.deltaTime;
                }

                // End of conversation

                if (conversation.stop || index >= conversation.sentences.Length)
                {
                    lockedBy = null;
                    index = 0;
                    delay = 0;

                    conversation.once = false;
                    conversation.stop = false;

                    message.conversation.text = "";
                    message.showConversation = false;
                }
            }
        }
    }
}