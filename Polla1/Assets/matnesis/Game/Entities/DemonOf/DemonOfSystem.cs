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

            // Found the demon!

            var playerDistance = Vector3.Distance(demonOf.transform.position, playerPos);
            if (playerDistance < 3)
                demonOf.touched = true;

            // Show up

            var dot = Vector3.Dot(player.forward, (demonOf.transform.position - playerPos).normalized);
            if (demonOf.show)
            {
                demonOf.collidr.enabled = true;
                demonOf.render.enabled = true;
            }
            else
            {
                if (dot < 0.20 && playerDistance > 3)
                {
                    demonOf.rigidBody.isKinematic = true;
                    demonOf.collidr.enabled = false;
                    demonOf.render.enabled = false;
                }
            }

            // Only if

            if (!demonOf.show || !demonOf.touched)
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
            behind.y = playerPos.y - 0.75f;

            farestDemon.transform.position = behind;
            farestDemon.transform.rotation = Quaternion.identity;
        }
    }
}