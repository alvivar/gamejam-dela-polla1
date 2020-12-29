using UnityEngine;

public class BecauseThisReasonSystem : MonoBehaviour
{
    SoundClip thunder;

    void Update()
    {
        if (!thunder)
            thunder = EntitySet.SoundClips.Filter(x => x.id == "ThunderOverTheHouse", first : true).Elements[0];

        var becauseThisReasons = EntitySet.GetBecauseThisReason(EntitySet.InteractPointIds);
        for (int i = 0; i < becauseThisReasons.Length; i++)
        {
            var becauseThisReason = becauseThisReasons.Elements[i];
            var interactPoint = EntitySet.GetInteractPoint(becauseThisReason);

            if (interactPoint.clicked > 0)
            {
                interactPoint.clicked = 0;
                interactPoint.noPrefix = true;
                interactPoint.content = becauseThisReason.trueReason;

                becauseThisReason.chosen = true;
                thunder.once = true;
            }
        }
    }
}