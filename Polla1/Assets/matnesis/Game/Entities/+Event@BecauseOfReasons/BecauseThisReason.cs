using UnityEngine;

// !Gigas
public class BecauseThisReason : MonoBehaviour
{
    public string reason;

    private void OnEnable()
    {
        EntitySet.AddBecauseThisReason(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveBecauseThisReason(this);
    }
}