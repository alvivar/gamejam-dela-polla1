using UnityEngine;

// !Gigas
public class HideOnEye : MonoBehaviour
{
    public bool showing = true;
    public bool flag;
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