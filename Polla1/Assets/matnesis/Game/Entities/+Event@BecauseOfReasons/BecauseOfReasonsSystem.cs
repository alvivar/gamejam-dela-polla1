using UnityEngine;

public class BecauseOfReasonsSystem : MonoBehaviour
{
    float timer;
    Interact interact;

    enum Stage { FirstKnock, WhyKnocking }
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
                    interact.content.text = "Why?";

                    timer = 0;
                    stage = Stage.WhyKnocking;
                }
            }

            // Knock judgement

            if (stage == Stage.WhyKnocking)
            {
                timer += Time.deltaTime;
                if (timer > 3)
                {
                    interactPoint.update = true;
                    stage = Stage.FirstKnock;
                }
            }
        }
    }
}