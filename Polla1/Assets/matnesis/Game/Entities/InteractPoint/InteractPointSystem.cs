using UnityEngine;

public class InteractPointSystem : MonoBehaviour
{
    Transform player;
    Interact interact;

    public int lockedBy = 0;

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

            Debug.Log($"Trying {interactPoint.GetInstanceID()} at {Time.time}");
            if (lockedBy != 0 && lockedBy != interactPoint.GetInstanceID())
            {
                Debug.Log($"Rejected {interactPoint} {interactPoint.GetInstanceID()} at {Time.time}", interactPoint.transform);
                return;
            }

            Debug.Log($"Inside {interactPoint} {interactPoint.GetInstanceID()} at {Time.time}", interactPoint.transform);

            var len = Vector3.Distance(pos, interactPoint.transform.position);

            if (len < interactPoint.distance)
            {
                lockedBy = interactPoint.GetInstanceID();

                interact.transform.position = interactPoint.transform.position;
                interact.content.text = interact.prefix + interactPoint.content;
                interact.show = true;
            }
            else
            {
                lockedBy = 0;

                interact.show = false;
            }
        }
    }
}