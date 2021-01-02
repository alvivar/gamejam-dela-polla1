using UnityEngine;

public class DemonInvitationSystem : MonoBehaviour
{
    void Update()
    {
        var demonInvitations = EntitySet.DemonInvitations;
        for (int i = 0; i < demonInvitations.Length; i++)
        {
            var demonInvitation = demonInvitations.Elements[i];

            if (demonInvitation.state == DemonInvitation.State.Idle)
                continue;

            if (demonInvitation.state == DemonInvitation.State.FirstCall)
            {

            }
        }
    }
}