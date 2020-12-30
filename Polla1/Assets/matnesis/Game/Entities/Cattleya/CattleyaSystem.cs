using UnityEngine;

public class CattleyaSystem : MonoBehaviour
{
    void Update()
    {
        var cattleyas = EntitySet.GetCattleya(EntitySet.InteractPointIds, EntitySet.ConversationIds);
        for (int i = 0; i < cattleyas.Length; i++)
        {
            var cattleya = cattleyas.Elements[i];
            var interactPoint = EntitySet.GetInteractPoint(cattleya);
            var conversation = EntitySet.GetConversation(cattleya);

            if (cattleya.state == Cattleya.State.Idle)
                continue;

            if (cattleya.state == cattleya.lastState)
                continue;

            // Bathroom

            if (cattleya.state == Cattleya.State.Bathroom)
            {
                cattleya.lastState = cattleya.state;

                for (int j = 0; j < cattleya.enableForCloth.Length; j++)
                    cattleya.enableForCloth[j].gameObject.SetActive(false);

                for (int j = 0; j < cattleya.disableForNaked.Length; j++)
                    cattleya.disableForNaked[j].gameObject.SetActive(true);

                cattleya.character.position = cattleya.bathroomPosition.position;
                cattleya.character.rotation = cattleya.bathroomPosition.rotation;
                cattleya.animator.SetTrigger("idleSad");

                interactPoint.update = false;
                interactPoint.interactable = false;
            }

            // AtTheDoor

            if (cattleya.state == Cattleya.State.AtTheDoor)
            {
                cattleya.lastState = cattleya.state;

                for (int j = 0; j < cattleya.enableForCloth.Length; j++)
                    cattleya.enableForCloth[j].gameObject.SetActive(true);

                for (int j = 0; j < cattleya.disableForNaked.Length; j++)
                    cattleya.disableForNaked[j].gameObject.SetActive(false);

                cattleya.character.position = cattleya.nearDoorPosition.position;
                cattleya.character.rotation = cattleya.nearDoorPosition.rotation;
                cattleya.animator.SetTrigger("idle");

                interactPoint.update = true;
                interactPoint.interactable = true;
            }
        }
    }
}