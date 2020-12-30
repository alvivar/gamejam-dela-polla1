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
    public float distance = 3.5f;
    public float dotApproved = 0.5f;
    public Transform positionSource;

    private void OnEnable()
    {
        EntitySet.AddInteractPoint(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveInteractPoint(this);
    }
}