using UnityEngine;

public class InteractPointSystem : MonoBehaviour
{
    public InteractPoint lockedBy;

    Transform player;
    Interact interact;

    void Update()
    {
        if (!player)
            player = EntitySet.VoidPlayers.Elements[0].transform;

        if (!interact)
            interact = EntitySet.Interacts.Elements[0];

        var pos = player.position;
        var interactPoints = EntitySet.InteractPoints;
        for (int i = 0; i < interactPoints.Length; i++)
        {
            var interactPoint = interactPoints.Elements[i];

            if (lockedBy != null && lockedBy != interactPoint)
                continue;

            var len = Vector3.Distance(pos, interactPoint.transform.position);
            if (len < interactPoint.distance)
            {
                lockedBy = interactPoint;

                interact.transform.position = interactPoint.transform.position;
                interact.content.text = interact.prefix + interactPoint.content;
                interact.show = true;
            }
            else
            {
                lockedBy = null;

                interact.show = false;
            }
        }
    }
}