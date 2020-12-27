using UnityEngine;

// !Gigas
public class Telepoint : MonoBehaviour
{
    private void OnEnable()
    {
        EntitySet.AddTelepoint(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveTelepoint(this);
    }
}