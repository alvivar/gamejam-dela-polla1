using UnityEngine;

// !Gigas
public class DemonInvitation : MonoBehaviour
{
    private void OnEnable()
    {
        EntitySet.AddDemonInvitation(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveDemonInvitation(this);
    }
}