using UnityEngine;

// !Gigas
public class HideOnEye : MonoBehaviour
{
    [Header("Internal")]
    public bool showing = true;
    public bool flag = false;
    public float clock = 0;

    [Header("Required Children")]
    public GameObject target;
    public GameObject[] targets;

    private void OnEnable()
    {
        EntitySet.AddHideOnEye(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveHideOnEye(this);
    }
}