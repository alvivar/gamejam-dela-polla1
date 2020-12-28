using UnityEngine;

// !Gigas
public class WatchingTheSea : MonoBehaviour
{
    private void OnEnable()
    {
        EntitySet.AddWatchingTheSea(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveWatchingTheSea(this);
    }
}