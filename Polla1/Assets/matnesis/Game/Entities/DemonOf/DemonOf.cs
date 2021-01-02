using UnityEngine;

// !Gigas !Alt
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

    private void Start()
    {
        EntitySet.AddAltDemonOf(this);
        // gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        EntitySet.RemoveAltDemonOf(this);
    }

}