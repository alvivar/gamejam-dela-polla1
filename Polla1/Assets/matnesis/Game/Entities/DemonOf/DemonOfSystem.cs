using UnityEngine;

public class DemonOfSystem : MonoBehaviour
{
    Transform player;

    void Update()
    {
        if (!player)
            player = EntitySet.VoidCams.Elements[0].transform;

        // Follow the player

        var playerPos = player.position;

        var closestDistance = 9999f;
        var farestDistance = 0f;
        var farestDemon = EntitySet.DemonOfs.Elements[0];

        var demonOfs = EntitySet.DemonOfs;
        for (int i = 0; i < demonOfs.Length; i++)
        {
            var demonOf = demonOfs.Elements[i];

            // Summon
            if (demonOf.show)
            {
                demonOf.rigidBody.gameObject.SetActive(true);
            }
            else
            {
                demonOf.rigidBody.gameObject.SetActive(false);
            }

            // Found the demon!

            var playerDistance = Vector3.Distance(demonOf.transform.position, playerPos);
            if (playerDistance < 3)
                demonOf.touched = true;

            // Only if found

            if (!demonOf.touched)
                continue;

            if (playerDistance < closestDistance)
            {
                closestDistance = playerDistance;
            }

            if (playerDistance > farestDistance)
            {
                farestDistance = playerDistance;
                farestDemon = demonOf;
            }

            // Look at the player

            var dot = Vector3.Dot(player.forward, (demonOf.transform.position - playerPos).normalized);
            if (dot < 0.20 && playerDistance > 3)
            {
                demonOf.rigidBody.isKinematic = false;
                demonOf.transform.LookAt(playerPos);
                demonOf.transform.eulerAngles = new Vector3(0, demonOf.transform.eulerAngles.y, 0);
            }
            else
            {
                demonOf.rigidBody.isKinematic = true;
            }
        }

        // Farest demon reposition

        var farestDot = Vector3.Dot(player.forward, (farestDemon.transform.position - playerPos).normalized);
        if (farestDemon.touched && closestDistance > 15 && farestDot < 0.20)
        {
            var randomPos = Random.insideUnitSphere * 10;
            var behind = -10 * player.forward + playerPos + randomPos;
            behind.y = playerPos.y - 0.6f;

            farestDemon.transform.position = behind;
            farestDemon.transform.rotation = Quaternion.identity;
        }
    }
}