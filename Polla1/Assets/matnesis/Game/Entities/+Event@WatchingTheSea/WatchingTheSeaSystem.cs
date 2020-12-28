using UnityEngine;

public class WatchingTheSeaSystem : MonoBehaviour
{
    void Update()
    {
        var watchingTheSeas = EntitySet.WatchingTheSeas;
        for (int i = 0; i < watchingTheSeas.Length; i++)
        {
            var watchingTheSea = watchingTheSeas.Elements[i];
        }
    }
}