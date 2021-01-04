using UnityEngine;

// !Gigas
public class DemonInvitation : MonoBehaviour
{
    public State state;
    public State lastState;
    public enum State
    {
        Idle,
        EnableDemons,
        OneAtTheTimeConversation,
        WaitingConversation,
        UntilLater
    }

    [Header("Required Children")]
    public Transform[] cabinPositions;

    private void OnEnable()
    {
        EntitySet.AddDemonInvitation(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveDemonInvitation(this);
    }
}