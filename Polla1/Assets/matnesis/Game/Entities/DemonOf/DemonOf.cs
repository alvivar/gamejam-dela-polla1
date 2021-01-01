using UnityEngine;

// !Gigas
public class DemonOf : MonoBehaviour
{
    private void OnEnable()
    {
        EntitySet.AddDemonOf(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveDemonOf(this);
    }
}