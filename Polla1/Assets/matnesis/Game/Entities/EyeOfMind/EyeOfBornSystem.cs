using UnityEngine;

public class EyeOfBornSystem : MonoBehaviour
{
    void Update()
    {
        var eyeOfBorns = EntitySet.EyeOfBorns;
        for (int i = 0; i < eyeOfBorns.Length; i++)
        {
            var eyeOfBorn = eyeOfBorns.Elements[i];
        }
    }
}