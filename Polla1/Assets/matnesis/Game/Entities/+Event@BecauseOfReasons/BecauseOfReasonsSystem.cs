using UnityEngine;

public class BecauseOfReasonsSystem : MonoBehaviour
{
    float timer;
    Interact interact;
    MainMessage message;

    enum Stage { TryToKnock, WhyKnocking, ReasonsJudgement }
    Stage stage = Stage.TryToKnock;

    void Update()
    {
        if (!interact)
            interact = EntitySet.Interacts.Elements[0];

        if (!message)
            message = EntitySet.MainMessages.Elements[0];

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

                    timer = 0;
                    stage = Stage.WhyKnocking;
                }
            }

            // Do you have enough reasons?

            if (stage == Stage.WhyKnocking)
            {
                timer += Time.deltaTime;
                if (timer > 2f)
                {
                    interactPoint.update = true;

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

                    stage = Stage.ReasonsJudgement;
                }

            }

            // Choose your reason

            if (stage == Stage.ReasonsJudgement)
            {
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
                        message.mainDamp = 10;
                        message.main.text = "\t\t*Knock knock*";
                        message.showMain = true;
                    }
                }

                // Make sure Interact comes back

                timer += Time.deltaTime;
                if (timer > 2f && !interactPoint.update)
                    interactPoint.update = true;
            }
        }
    }
}