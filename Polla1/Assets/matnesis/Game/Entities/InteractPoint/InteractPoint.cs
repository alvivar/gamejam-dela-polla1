using UnityEngine;

// !Gigas
public class InteractPoint : MonoBehaviour
{
    private void OnEnable()
    {
        EntitySet.AddInteractPoint(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveInteractPoint(this);
    }
}