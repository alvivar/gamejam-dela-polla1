using UnityEngine;

public class TheGunSystem : MonoBehaviour
{
    void Update()
    {
        var theGuns = EntitySet.TheGuns;
        for (int i = 0; i < theGuns.Length; i++)
        {
            var theGun = theGuns.Elements[i];
        }
    }
}