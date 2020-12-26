using UnityEngine;

public class VoidDetectionSystem : MonoBehaviour
{
    void Update()
    {
        var voidDetections = EntitySet.VoidDetections;
        for (int i = 0; i < voidDetections.Length; i++)
        {
            var voidDetection = voidDetections.Elements[i];
        }
    }
}