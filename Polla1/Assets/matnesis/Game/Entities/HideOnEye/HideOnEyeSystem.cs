using UnityEngine;

public class HideOnEyeSystem : MonoBehaviour
{
    public float playerDistance;
    public float dot;

    Transform player;

    void Update()
    {
        if (!player)
            player = EntitySet.VoidCams.Elements[0].transform;

        var hideOnEyes = EntitySet.HideOnEyes;
        for (int i = 0; i < hideOnEyes.Length; i++)
        {
            var hideOnEye = hideOnEyes.Elements[i];

            if (!hideOnEye.update)
                continue;

            if (hideOnEye.clock > Time.time)
                continue;

            if (hideOnEye.targets.Length < 1)
                continue;

            var hidePos = hideOnEye.target.transform.position;
            var playerPos = player.transform.position;

            playerDistance = Vector3.Distance(hidePos, playerPos);

            if (playerDistance < 25)
                continue;

            dot = Vector3.Dot(player.forward, (hidePos - playerPos).normalized);

            if (dot < 0.20f)
            {
                if (!hideOnEye.flag)
                {
                    hideOnEye.flag = true;
                    hideOnEye.clock = Time.time + 2;
                    hideOnEye.showing = !hideOnEye.showing;

                    for (int j = 0; j < hideOnEye.targets.Length; j++)
                    {
                        hideOnEye.targets[j].SetActive(hideOnEye.showing);
                    }
                }
            }
            else
            {
                hideOnEye.flag = false;
            }
        }
    }
}