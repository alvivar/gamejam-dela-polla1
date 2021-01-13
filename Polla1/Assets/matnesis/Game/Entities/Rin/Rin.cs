using UnityEngine;

// !Gigas
public class Rin : MonoBehaviour
{
    [Header("Required Children")]
    public Transform character;
    public Transform prayingLocation;
    public Transform doorLocation;
    public Animator animator;

    [Header("State")]
    public State state = State.Praying;
    public State lastState = State.Idle;
    public enum State { Idle, Praying, AtTheDoor, Talking, WaitingConversation }

    private void OnEnable()
    {
        EntitySet.AddRin(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveRin(this);
        state = State.Praying;
        lastState = State.Idle;
    }
}