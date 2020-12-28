using UnityEngine;

// !Gigas
public class Conversation : MonoBehaviour
{
    public bool once = false;
    public bool stop = false;
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
    public float delay;
    public AudioClip clip;
}