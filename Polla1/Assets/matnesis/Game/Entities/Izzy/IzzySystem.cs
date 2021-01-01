using UnityEngine;

public class IzzySystem : MonoBehaviour
{
    void Update()
    {
        var izzys = EntitySet.Izzys;
        for (int i = 0; i < izzys.Length; i++)
        {
            var izzy = izzys.Elements[i];
        }
    }
}