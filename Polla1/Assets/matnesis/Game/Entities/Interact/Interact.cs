using TMPro;
using UnityEngine;

// !Gigas
public class Interact : MonoBehaviour
{
    public bool show = false;
    public float damp = 10;

    [Header("Required Children")]
    public TextMeshPro content;
    public SpriteRenderer background;

    private void OnEnable()
    {
        EntitySet.AddInteract(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveInteract(this);
    }
}