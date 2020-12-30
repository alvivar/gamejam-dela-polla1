using UnityEngine;

// !Gigas
public class Cattleya : MonoBehaviour
{
    [Header("Required Children")]
    public Transform character;
    public Transform bathroomPosition;
    public Transform nearDoorPosition;
    public Animator animator;

    public Transform[] enableForCloth;
    public Transform[] disableForNaked;

    [Header("State")]
    public State state = State.Bathroom;
    public State lastState = State.Idle;
    public enum State { Idle, Bathroom, AtTheDoor }

    private void OnEnable()
    {
        EntitySet.AddCattleya(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveCattleya(this);
    }
}