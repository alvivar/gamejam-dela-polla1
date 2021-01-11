using UnityEngine;

public class BecauseOfReasonsSystem : MonoBehaviour
{
    float timer;
    Interact interact;
    PartyHouse partyHouse;
    DemonInvitation demonInvitation;
    EyeOfCreator eyeOfCreator;

    enum Stage { TryToKnock, WhyKnocking, ReasonsJudgement, Idle }
    Stage stage = Stage.TryToKnock;

    void Update()
    {
        if (!interact)
            interact = EntitySet.Interacts.Elements[0];

        if (!partyHouse)
            partyHouse = EntitySet.PartyHouses.Elements[0];

        if (!demonInvitation)
            demonInvitation = EntitySet.DemonInvitations.Elements[0];

        if (!eyeOfCreator)
            eyeOfCreator = EntitySet.EyeOfCreators.Elements[0];

        var becauseOfReasonss = EntitySet.GetBecauseOfReasons(EntitySet.InteractPointIds);
        for (int i = 0; i < becauseOfReasonss.Length; i++)
        {
            var becauseOfReasons = becauseOfReasonss.Elements[i];
            var interactPoint = EntitySet.GetInteractPoint(becauseOfReasons);

            // Try to knock, but you need reasons

            if (stage == Stage.TryToKnock)
            {
                if (interactPoint.clicked > 0)
                {
                    interactPoint.clicked = 0;
                    interactPoint.update = false;
                    interact.content.text = Texts.WHY;

                    // Demons
                    demonInvitation.state = DemonInvitation.State.EnableDemons;

                    timer = 0;
                    stage = Stage.ReasonsJudgement;
                }
            }

            // The demons gives you reasons

            if (stage == Stage.ReasonsJudgement)
            {
                // Make sure Interact comes back, make sure the reasons are
                // enabled when the demons finish talking

                if (stage == Stage.ReasonsJudgement)
                {
                    timer += Time.deltaTime;
                    if (timer > 2f && !interactPoint.update)
                    {
                        interactPoint.update = true;

                        // Wait until the demons finish the conversation to
                        // unlock the reason
                        if (demonInvitation.state == DemonInvitation.State.UntilLater)
                        {
                            // Set the reasons
                            var reasons = EntitySet.GetBecauseThisReason(EntitySet.InteractPointIds);
                            for (int j = 0; j < reasons.Length; j++)
                            {
                                var reason = reasons.Elements[j];
                                var interactReason = EntitySet.GetInteractPoint(reason);

                                interactReason.interactable = true;
                                interactReason.noPrefix = false;
                                interactReason.content = reason.reason;
                            }
                        }
                    }
                }

                // Try a reason, try to knock

                if (interactPoint.clicked > 0)
                {
                    interactPoint.clicked = 0;

                    // Count the reasons

                    var count = 0;
                    var reasons = EntitySet.GetBecauseThisReason(EntitySet.InteractPointIds);
                    for (int j = 0; j < reasons.Length; j++)
                    {
                        var reason = reasons.Elements[j];
                        if (reason.chosen)
                            count += 1;
                    }

                    // Are they enough?

                    if (count < EntitySet.BecauseThisReasons.Length)
                    {
                        interactPoint.update = false;

                        if (count > 0) interact.content.text = Texts.NOT_ENOUGH_REASONS;
                        else interact.content.text = Texts.WHY;

                        timer = 0;
                    }
                    else
                    {
                        // This script is over, let's turn down systems and go to
                        // the next scripting stage

                        timer = 0;
                        interactPoint.enabled = false;
                        interact.show = false;

                        reasons = EntitySet.GetBecauseThisReason(EntitySet.InteractPointIds);
                        for (int j = 0; j < reasons.Length; j++)
                        {
                            var reason = reasons.Elements[j];
                            var interactReason = EntitySet.GetInteractPoint(reason);

                            reason.enabled = false;
                            interactReason.enabled = false;
                        }

                        // Next scripting

                        eyeOfCreator.New("Why?");

                        partyHouse.state = PartyHouse.State.SetUpGirlAtDoor;

                        stage = Stage.Idle;
                        enabled = false;
                    }
                }
            }
        }
    }
}