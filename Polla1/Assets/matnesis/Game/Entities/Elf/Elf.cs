using UnityEngine;

// !Gigas
public class Elf : MonoBehaviour
{
    [Header("State")]
    public State state = State.Start;
    public State lastState = State.Idle;
    public enum State { Idle, Start }

    private void OnEnable()
    {
        EntitySet.AddElf(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveElf(this);
    }
}