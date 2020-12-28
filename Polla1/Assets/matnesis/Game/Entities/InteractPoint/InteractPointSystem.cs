using UnityEngine;

public class InteractPointSystem : MonoBehaviour
{
    void Update()
    {
        var interactPoints = EntitySet.InteractPoints;
        for (int i = 0; i < interactPoints.Length; i++)
        {
            var interactPoint = interactPoints.Elements[i];
        }
    }
}