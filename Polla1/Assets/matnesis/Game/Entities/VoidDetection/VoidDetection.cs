using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

// !Gigas
public class VoidDetection : MonoBehaviour
{
    [Header("Required Children")]
    public FirstPersonController fps;

    private void OnEnable()
    {
        EntitySet.AddVoidDetection(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveVoidDetection(this);
    }
}