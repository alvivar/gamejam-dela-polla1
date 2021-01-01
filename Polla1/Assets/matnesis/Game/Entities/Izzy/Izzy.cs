using UnityEngine;

// !Gigas
public class Izzy : MonoBehaviour
{
    private void OnEnable()
    {
        EntitySet.AddIzzy(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveIzzy(this);
    }
}