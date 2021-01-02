using UnityEngine;

// !Gigas
public class BecauseOfReasons : MonoBehaviour
{
    private void OnEnable()
    {
        EntitySet.AddBecauseOfReasons(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveBecauseOfReasons(this);
    }
}