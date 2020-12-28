using UnityEngine;

public class BecauseOfReasonsSystem : MonoBehaviour
{
    float timer;
    Interact interact;

    enum Stage { FirstKnock, WhyKnocking, ChooseAReason }
    Stage stage = Stage.FirstKnock;

    void Update()
    {
        if (!interact)
            interact = EntitySet.Interacts.Elements[0];

        var becauseOfReasonss = EntitySet.GetBecauseOfReasons(EntitySet.InteractPointIds);
        for (int i = 0; i < becauseOfReasonss.Length; i++)
        {
            var becauseOfReasons = becauseOfReasonss.Elements[i];
            var interactPoint = EntitySet.GetInteractPoint(becauseOfReasons);

            // Try to knock

            if (stage == Stage.FirstKnock)
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

            // Knock judgement

            if (stage == Stage.WhyKnocking)
            {
                timer += Time.deltaTime;
                if (timer > 2f)
                {
                    interactPoint.update = true;
                    stage = Stage.FirstKnock;

                    // Time to make sure about the questions
                    var reasons = EntitySet.GetBecauseThisReason(EntitySet.InteractPointIds);
                    for (int j = 0; j < reasons.Length; j++)
                    {
                        var reason = reasons.Elements[j];
                        var interactReason = EntitySet.GetInteractPoint(reason);

                        interactReason.interactable = true;
                        interactReason.noPrefix = false;
                        interactReason.content = reason.reason;
                    }

                    stage = Stage.ChooseAReason;
                }

            }

            // Choose your reason

            if (stage == Stage.ChooseAReason)
            {
                if (interactPoint.clicked > 0)
                {
                    interactPoint.clicked = 0;
                    interactPoint.update = false;
                    interact.content.text = "TOTODILE";
                }
            }
        }
    }
}