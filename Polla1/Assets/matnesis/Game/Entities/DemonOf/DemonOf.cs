using UnityEngine;

// !Gigas !Alt
public class DemonOf : MonoBehaviour
{
    public bool show = false;
    public bool touched = false;

    [Header("Required Children")]
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