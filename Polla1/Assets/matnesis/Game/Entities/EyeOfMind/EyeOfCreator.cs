using UnityEngine;

// !Gigas
public class EyeOfCreator : MonoBehaviour
{
    private void OnEnable()
    {
        EntitySet.AddEyeOfCreator(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveEyeOfCreator(this);
    }
}