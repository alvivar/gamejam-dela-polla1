using UnityEngine;

// !Gigas
public class BecauseThisReason : MonoBehaviour
{
    public bool chosen = false;
    public string reason;
    public string trueReason;

    private void OnEnable()
    {
        EntitySet.AddBecauseThisReason(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveBecauseThisReason(this);
    }
}