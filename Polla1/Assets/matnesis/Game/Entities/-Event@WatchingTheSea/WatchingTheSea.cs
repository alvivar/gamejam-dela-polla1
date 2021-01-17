using UnityEngine;

// !Gigas
public class WatchingTheSea : MonoBehaviour
{
    public enum State { Idle, CanDialog, Talking }
    public State state = State.CanDialog;

    private void OnEnable()
    {
        EntitySet.AddWatchingTheSea(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveWatchingTheSea(this);
    }
}