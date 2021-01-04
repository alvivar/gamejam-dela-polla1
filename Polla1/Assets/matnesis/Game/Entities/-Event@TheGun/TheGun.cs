using UnityEngine;

// !Gigas
public class TheGun : MonoBehaviour
{
    public Transform rifle;

    private void OnEnable()
    {
        EntitySet.AddTheGun(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveTheGun(this);
    }
}