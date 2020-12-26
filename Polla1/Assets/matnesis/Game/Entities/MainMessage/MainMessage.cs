using UnityEngine;

// !Gigas
public class MainMessage : MonoBehaviour
{
    private void OnEnable()
    {
        EntitySet.AddMainMessage(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveMainMessage(this);
    }
}