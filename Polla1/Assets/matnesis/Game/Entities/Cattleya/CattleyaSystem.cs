using UnityEngine;

public class CattleyaSystem : MonoBehaviour
{
    void Update()
    {
        var cattleyas = EntitySet.Cattleyas;
        for (int i = 0; i < cattleyas.Length; i++)
        {
            var cattleya = cattleyas.Elements[i];
        }
    }
}