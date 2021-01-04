using UnityEngine;

public class TheGunSystem : MonoBehaviour
{
    MainMessage mainMessage;
    Interact interact;

    void Update()
    {
        if (!mainMessage)
            mainMessage = EntitySet.MainMessages.Elements[0];

        if (interact)
            interact = EntitySet.Interacts.Elements[0];

        var theGuns = EntitySet.GetTheGun(EntitySet.InteractPointIds);
        for (int i = 0; i < theGuns.Length; i++)
        {
            var theGun = theGuns.Elements[i];
            var interactPoint = EntitySet.GetInteractPoint(theGun);

            if (interactPoint.clicked > 0)
            {
                interactPoint.clicked = 0;

                interactPoint.update = false;

                this.tt("TheGunDoesntWantYou")
                    .Reset()
                    .Add(() =>
                    {
                        mainMessage.main.text = "";
                        mainMessage.main.text += "\t\tThe gun doesn't want to be stolen.\n\n";

                        mainMessage.mainDamp = 10;
                        mainMessage.showMain = true;
                    })
                    .Add(4, () =>
                    {
                        mainMessage.main.text = "";
                        mainMessage.main.text += "\t\t\"I belong to the huntress\n";
                        mainMessage.main.text += "\t\t\tthat no one remembers but me...\"";
                    })
                    .Add(2, () =>
                    {
                        mainMessage.mainDamp = 1f;
                        mainMessage.showMain = false;

                        interactPoint.update = true;
                    });
            }
        }
    }
}