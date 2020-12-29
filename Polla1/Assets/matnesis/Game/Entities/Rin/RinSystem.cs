using UnityEngine;

public class RinSystem : MonoBehaviour
{
    void Update()
    {
        var rins = EntitySet.Rins;
        for (int i = 0; i < rins.Length; i++)
        {
            var rin = rins.Elements[i];

            if (rin.state == Rin.State.Idle)
                continue;

            if (rin.state == rin.lastState)
                continue;

            if (rin.state == Rin.State.Praying)
            {
                rin.lastState = rin.state;

                rin.character.position = rin.prayingLocation.position;
                rin.character.rotation = rin.prayingLocation.rotation;
                rin.animator.SetTrigger("praying");
            }

            if (rin.state == Rin.State.AtTheDoor)
            {
                rin.lastState = rin.state;

                rin.character.position = rin.doorLocation.position;
                rin.character.rotation = rin.doorLocation.rotation;
                rin.animator.SetTrigger("idle");
            }
        }
    }
}