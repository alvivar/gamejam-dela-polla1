using UnityEngine;

public class InteractPointSystem : MonoBehaviour
{
    public InteractPoint lockedBy;

    Transform player;
    Interact interact;

    void Update()
    {
        if (!player)
            player = EntitySet.VoidCams.Elements[0].transform;

        if (!interact)
            interact = EntitySet.Interacts.Elements[0];

        var pos = player.position;
        var interactPoints = EntitySet.InteractPoints;
        for (int i = 0; i < interactPoints.Length; i++)
        {
            var interactPoint = interactPoints.Elements[i];

            if (!interactPoint.update)
                continue;

            if (lockedBy != null && lockedBy != interactPoint)
                continue;

            var dot = Vector3.Dot(player.forward, (interactPoint.transform.position - pos).normalized);
            if (dot < 0.6f)
            {
                lockedBy = null;
                continue;
            }

            var len = Vector3.Distance(pos, interactPoint.transform.position);
            if (len < interactPoint.distance)
            {
                lockedBy = interactPoint;

                interact.transform.position = interactPoint.transform.position;

                var prefix = interactPoint.noPrefix ? "" : interact.prefix;
                interact.content.text = prefix + interactPoint.content;
                interact.show = true;

                if (interactPoint.interactable && Input.GetKeyDown(KeyCode.E))
                    interactPoint.clicked += 1;
            }
            else
            {
                lockedBy = null;

                interact.show = false;
            }
        }
    }
}