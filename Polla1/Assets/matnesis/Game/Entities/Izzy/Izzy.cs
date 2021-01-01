using UnityEngine;

// !Gigas
public class Izzy : MonoBehaviour
{
    [Header("Required Children")]
    public Transform character;
    public Animator animator;

    [Header("State")]
    public State state = State.Sleeping;
    public State lastState = State.Idle;
    public enum State { Idle, Sleeping, Talking, WaitingConversation }

    private void OnEnable()
    {
        EntitySet.AddIzzy(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveIzzy(this);
    }
}