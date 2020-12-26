using UnityEngine;

// !Gigas
public class VoidDetection : MonoBehaviour
{
    private void OnEnable()
    {
        EntitySet.AddVoidDetection(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveVoidDetection(this);
    }
}