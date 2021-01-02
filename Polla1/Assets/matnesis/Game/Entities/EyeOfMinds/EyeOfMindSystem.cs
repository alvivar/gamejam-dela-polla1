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
            var eyeOfMind = eyeOfMinds.Elements[i];

            if (eyeOfMind.transform.position.magnitude == 0)
                eyeOfMind.transform.position = eyeOfMind.transform.position + Random.insideUnitSphere;

            var eyeOfMindPos = eyeOfMind.transform.position;
            var playerPos = player.transform.position;

            // Ignore on player sight

            var dot = Vector3.Dot(player.forward, (eyeOfMindPos - playerPos).normalized);
            if (dot > 0.2f)
                continue;

            // Closest eye to self

            closestEye = null;
            var closestDistance = 9999f;
            for (int j = 0; j < eyeOfMinds.Length; j++)
            {
                var otherEye = eyeOfMinds.Elements[j];

                if (eyeOfMind == otherEye)
                    continue;

                var otherEyePos = otherEye.transform.position;

                if (eyeOfMindPos == otherEyePos)
                    otherEye.transform.position += Random.insideUnitSphere;

                // Distance

                var distance = Vector3.Distance(eyeOfMindPos, otherEyePos);

                if (distance < closestDistance && distance < 9)
                {
                    closestDistance = distance;
                    closestEye = otherEye.transform;
                }
            }

            // Get away from other eyes

            if (closestEye)
            {
                var awayDir = -1 * (closestEye.transform.position - eyeOfMindPos).normalized;
                eyeOfMind.transform.position = Vector3.Lerp(eyeOfMindPos, eyeOfMindPos + awayDir, Time.deltaTime * damp);
            }

            // But follow the player

            var playerDistance = Vector3.Distance(eyeOfMindPos, playerPos);
            if (playerDistance > 3f)
            {
                eyeOfMind.transform.position = Vector3.Lerp(eyeOfMindPos, playerPos, Time.deltaTime * damp);
            }

            // Don't go below

            if (eyeOfMindPos.y < (playerPos.y - 0.5f))
            {
                eyeOfMind.transform.position = Vector3.Lerp(eyeOfMindPos, eyeOfMindPos + Vector3.up, Time.deltaTime * damp);
            }
        }
    }
}