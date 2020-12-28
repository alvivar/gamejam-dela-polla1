using UnityEngine;

// !Gigas
public class LookAtVoidPlayer : MonoBehaviour
{
    private void OnEnable()
    {
        EntitySet.AddLookAtVoidPlayer(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveLookAtVoidPlayer(this);
    }
}