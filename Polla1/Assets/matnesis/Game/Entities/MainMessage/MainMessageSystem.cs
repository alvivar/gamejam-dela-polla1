using UnityEngine;

public class MainMessageSystem : MonoBehaviour
{
    void Update()
    {
        var mainMessages = EntitySet.MainMessages;
        for (int i = 0; i < mainMessages.Length; i++)
        {
            var mainMessage = mainMessages.Elements[i];
        }
    }
}