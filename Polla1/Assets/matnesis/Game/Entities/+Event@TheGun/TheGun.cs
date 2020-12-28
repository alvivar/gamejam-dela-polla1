using UnityEngine;

// !Gigas
public class TheGun : MonoBehaviour
{
    private void OnEnable()
    {
        EntitySet.AddTheGun(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveTheGun(this);
    }
}