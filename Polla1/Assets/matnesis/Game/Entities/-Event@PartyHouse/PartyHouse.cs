using UnityEngine;

// !Gigas
public class PartyHouse : MonoBehaviour
{
    public State state = State.Idle;
    public State lastState = State.Idle;
    public enum State
    {
        Idle,
        SetUpGirlAtDoor,
        GirlAnsweringTheDoor,
        PlayerForceEnteringTheHouse
    }

    [Header("Required Children")]
    public Animator animator;

    private void OnEnable()
    {
        EntitySet.AddPartyHouse(this);
    }

    private void OnDisable()
    {
        EntitySet.RemovePartyHouse(this);
    }
}