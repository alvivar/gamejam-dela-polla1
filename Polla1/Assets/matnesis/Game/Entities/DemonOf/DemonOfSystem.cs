using UnityEngine;

public class DemonOfSystem : MonoBehaviour
{
    void Update()
    {
        var demonOfs = EntitySet.DemonOfs;
        for (int i = 0; i < demonOfs.Length; i++)
        {
            var demonOf = demonOfs.Elements[i];
        }
    }
}