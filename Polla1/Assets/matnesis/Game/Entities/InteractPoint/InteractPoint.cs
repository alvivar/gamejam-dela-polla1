using UnityEngine;

// !Gigas
public class InteractPoint : MonoBehaviour
{
    public bool update = true;
    public bool interactable = true;
    public bool noPrefix = false;
    public int clicked = 0;

    [Header("Config")]
    public string content = "[E] Interact";
    public float distance = 5;
    public float dotApproved = 0.5f;

    private void OnEnable()
    {
        EntitySet.AddInteractPoint(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveInteractPoint(this);
    }
}