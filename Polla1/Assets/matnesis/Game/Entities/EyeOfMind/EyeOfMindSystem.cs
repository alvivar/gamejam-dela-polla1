using UnityEngine;

public class EyeOfMindSystem : MonoBehaviour
{
    Transform player;
    Transform closestEye;

    float damp = 9;

    void Update()
    {
        if (!player)
            player = EntitySet.VoidCams.Elements[0].transform;

        var eyeOfMinds = EntitySet.EyeOfMinds;
        for (int i = 0; i < eyeOfMinds.Length; i++)
        {
            var eye = eyeOfMinds.Elements[i];

            if (eye.state != EyeOfMind.State.EyeOfMind)
                continue;

            var eyePos = eye.transform.position;
            var playerPos = player.transform.position;

            // Ignore on player sight

            var dot = Vector3.Dot(player.forward, (eyePos - playerPos).normalized);
            if (dot > 0.20f)
                continue;

            // Closest eye to self

            closestEye = null;
            var closestDistance = 9999f;
            for (int j = 0; j < eyeOfMinds.Length; j++)
            {
                var otherEye = eyeOfMinds.Elements[j];

                if (eye == otherEye)
                    continue;

                var otherEyePos = otherEye.transform.position;

                if (eyePos == otherEyePos)
                    otherEye.transform.position += Random.insideUnitSphere;

                // Distance

                var distance = Vector3.Distance(eyePos, otherEyePos);

                if (distance < closestDistance && distance < 9)
                {
                    closestDistance = distance;
                    closestEye = otherEye.transform;
                }
            }

            // Get away from other eyes

            if (closestEye)
            {
                var awayDir = -1 * (closestEye.transform.position - eyePos).normalized;
                eye.transform.position = Vector3.Lerp(eyePos, eyePos + awayDir, Time.deltaTime * damp);
            }

            // But follow the player

            var playerDistance = Vector3.Distance(eyePos, playerPos);
            if (playerDistance > 3f)
            {
                eye.transform.position = Vector3.Lerp(eyePos, playerPos, Time.deltaTime * damp);
            }

            // But don't be over the player
            if (playerDistance < 2)
            {
                eye.transform.position = Vector3.Lerp(eyePos, eyePos + Vector3.up, Time.deltaTime * damp);
            }

            // Don't go below

            if (eyePos.y < (playerPos.y - 0.6f))
            {
                eye.transform.position = Vector3.Lerp(eyePos, eyePos + Vector3.up, Time.deltaTime * damp);
            }
        }
    }
}