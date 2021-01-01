using UnityEngine;

// !Gigas
public class DemonOf : MonoBehaviour
{
    public bool found = false;
    public Rigidbody rigidBody;

    private void OnEnable()
    {
        EntitySet.AddDemonOf(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveDemonOf(this);
    }
}