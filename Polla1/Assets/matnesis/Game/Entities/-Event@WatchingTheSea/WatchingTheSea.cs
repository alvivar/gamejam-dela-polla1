using UnityEngine;

// !Gigas
public class WatchingTheSea : MonoBehaviour
{
    public enum State { Idle, CanDialog, Talking, AskingForHelp }
    public State state = State.CanDialog;
    public State lastState = State.Idle;

    private void OnEnable()
    {
        EntitySet.AddWatchingTheSea(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveWatchingTheSea(this);
    }
}