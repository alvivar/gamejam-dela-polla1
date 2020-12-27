using UnityEngine;

public class MainMessageSystem : MonoBehaviour
{
    void Update()
    {
        var mainMessages = EntitySet.MainMessages;
        for (int i = 0; i < mainMessages.Length; i++)
        {
            var mainMessage = mainMessages.Elements[i];

            // Main

            if (mainMessage.showMain)
            {
                mainMessage.background.color = Color.Lerp(mainMessage.background.color, Colorf.ColorAlpha(Color.black, 1), Time.deltaTime * mainMessage.mainDamp);
                mainMessage.main.color = Color.Lerp(mainMessage.main.color, Colorf.ColorAlpha(Color.white, 1), Time.deltaTime * mainMessage.mainDamp);
            }
            else
            {
                mainMessage.background.color = Color.Lerp(mainMessage.background.color, Colorf.ColorAlpha(mainMessage.background.color, 0), Time.deltaTime * mainMessage.mainDamp);
                mainMessage.main.color = Color.Lerp(mainMessage.main.color, Colorf.ColorAlpha(mainMessage.main.color, 0), Time.deltaTime * mainMessage.mainDamp);
            }

            // Conversation

            if (mainMessage.showConversation)
            {
                mainMessage.conversationBackground.color = Color.Lerp(mainMessage.conversationBackground.color, Colorf.ColorAlpha(Color.white, 1), Time.deltaTime * mainMessage.conversationDamp);
                mainMessage.conversation.color = Color.Lerp(mainMessage.conversation.color, Colorf.ColorAlpha(Color.white, 1), Time.deltaTime * mainMessage.conversationDamp);
            }
            else
            {
                mainMessage.conversationBackground.color = Color.Lerp(mainMessage.conversationBackground.color, Colorf.ColorAlpha(mainMessage.conversationBackground.color, 0), Time.deltaTime * mainMessage.conversationDamp);
                mainMessage.conversation.color = Color.Lerp(mainMessage.conversation.color, Colorf.ColorAlpha(mainMessage.conversation.color, 0), Time.deltaTime * mainMessage.conversationDamp);
            }
        }
    }
}