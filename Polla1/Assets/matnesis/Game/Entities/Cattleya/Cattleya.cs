using UnityEngine;

// !Gigas
public class Cattleya : MonoBehaviour
{
    private void OnEnable()
    {
        EntitySet.AddCattleya(this);
    }

    private void OnDisable()
    {
        EntitySet.RemoveCattleya(this);
    }
}