using UnityEngine;

// !Gigas
public class DemonInvitation : MonoBehaviour
{
    public bool update = false;

    public State state;
    public State lastState;
    public enum State
    {
        Idle,
        FirstCall,
        OneAtTheTime

    }

    private void OnEnable()
    {
        EntitySet.AddDemonInvitation(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveDemonInvitation(this);
    }
}