using UnityEngine;

public class EyeOfCreatorSystem : MonoBehaviour
{
    void Update()
    {
        var eyeOfCreators = EntitySet.EyeOfCreators;
        for (int i = 0; i < eyeOfCreators.Length; i++)
        {
            var eyeOfCreator = eyeOfCreators.Elements[i];
        }
    }
}