using UnityEngine;

// !Gigas
public class VoidCam : MonoBehaviour
{
    private void OnEnable()
    {
        EntitySet.AddVoidCam(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveVoidCam(this);
    }
}