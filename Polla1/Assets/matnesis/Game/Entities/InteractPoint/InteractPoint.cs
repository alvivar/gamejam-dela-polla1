using UnityEngine;

// !Gigas
public class InteractPoint : MonoBehaviour
{
    public string content = "[E] Interact";
    public float distance = 5;

    private void OnEnable()
    {
        EntitySet.AddInteractPoint(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveInteractPoint(this);
    }
}