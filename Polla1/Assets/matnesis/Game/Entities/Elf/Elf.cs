using UnityEngine;

// !Gigas
public class Elf : MonoBehaviour
{
    [Header("State")]
    public State state = State.WatchingTheSea;
    public State lastState = State.Idle;
    public enum State { Idle, WatchingTheSea, Sad }

    [Header("Required")]
    public Animator animator;

    private void OnEnable()
    {
        EntitySet.AddElf(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveElf(this);
    }
}