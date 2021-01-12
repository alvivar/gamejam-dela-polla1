using UnityEngine;

// !Gigas
public class HideOnEye : MonoBehaviour
{
    private void OnEnable()
    {
        EntitySet.AddHideOnEye(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveHideOnEye(this);
    }
}