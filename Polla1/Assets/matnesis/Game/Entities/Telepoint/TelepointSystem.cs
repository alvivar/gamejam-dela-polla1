using UnityEngine;

public class TelepointSystem : MonoBehaviour
{
    int index = 0;

    VoidPlayer player;

    void Update()
    {
        if (!player)
            player = EntitySet.VoidPlayers.Elements[0];

        if (Input.GetKeyDown(KeyCode.P))
        {
            player.fps.enabled = false;
            player.transform.position = EntitySet.Telepoints.Elements[index].transform.position + new Vector3(0, 1, 0);
            index = ++index % EntitySet.Telepoints.Length;

            this.tt("EnableFPS")
                .Reset()
                .Add(0.5f, () => player.fps.enabled = true);
        }
    }
}