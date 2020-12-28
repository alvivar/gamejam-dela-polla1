using UnityEngine;

public class LookAtVoidPlayerSystem : MonoBehaviour
{
    Transform player;

    void Update()
    {
        if (!player)
            player = EntitySet.VoidPlayers.Elements[0].transform;

        var lookAtVoidPlayers = EntitySet.LookAtVoidPlayers;
        for (int i = 0; i < lookAtVoidPlayers.Length; i++)
        {
            var lookAtVoidPlayer = lookAtVoidPlayers.Elements[i];
            lookAtVoidPlayer.transform.LookAt(player);
        }
    }
}