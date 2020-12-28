using UnityEngine;

public class InteractSystem : MonoBehaviour
{
    void Update()
    {
        var interacts = EntitySet.Interacts;
        for (int i = 0; i < interacts.Length; i++)
        {
            var interact = interacts.Elements[i];
        }
    }
}