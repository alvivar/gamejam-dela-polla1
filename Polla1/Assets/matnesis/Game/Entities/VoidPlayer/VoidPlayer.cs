using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

// !Gigas
public class VoidPlayer : MonoBehaviour
{
    [Header("Required Children")]
    public FirstPersonController fps;

    private void OnEnable()
    {
        EntitySet.AddVoidPlayer(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveVoidPlayer(this);
    }
}