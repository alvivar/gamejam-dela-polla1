using UnityEngine;

// !Gigas
public class EyeOfBorn : MonoBehaviour
{
    private void OnEnable()
    {
        EntitySet.AddEyeOfBorn(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveEyeOfBorn(this);
    }
}