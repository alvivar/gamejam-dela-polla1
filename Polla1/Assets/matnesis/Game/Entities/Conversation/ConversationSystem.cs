using UnityEngine;

public class ConversationSystem : MonoBehaviour
{
    void Update()
    {
        var conversations = EntitySet.Conversations;
        for (int i = 0; i < conversations.Length; i++)
        {
            var conversation = conversations.Elements[i];
        }
    }
}