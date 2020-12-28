using UnityEngine;

// !Gigas
public class Interact : MonoBehaviour
{
    private void OnEnable()
    {
        EntitySet.AddInteract(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveInteract(this);
    }
}