using UnityEngine;

// !Gigas
public class DemonOf : MonoBehaviour
{
    public bool show = false;
    public bool touched = false;

    [Header("Required Children")]
    public Rigidbody rigidBody;
    public BoxCollider collidr;
    public Renderer render;

    private void OnEnable()
    {
        EntitySet.AddDemonOf(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveDemonOf(this);
    }
}