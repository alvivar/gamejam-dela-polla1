using UnityEngine;

// !Gigas
public class Conversation : MonoBehaviour
{
    public ConversationSentence[] sentences;

    private void OnEnable()
    {
        EntitySet.AddConversation(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveConversation(this);
    }
}

[System.Serializable]
public class ConversationSentence
{
    public string say;
    public string delay;
    public AudioClip clip;
}