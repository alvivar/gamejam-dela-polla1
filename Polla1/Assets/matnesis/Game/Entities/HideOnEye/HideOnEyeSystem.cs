using UnityEngine;

public class HideOnEyeSystem : MonoBehaviour
{
    void Update()
    {
        var hideOnEyes = EntitySet.HideOnEyes;
        for (int i = 0; i < hideOnEyes.Length; i++)
        {
            var hideOnEye = hideOnEyes.Elements[i];

        }
    }
}