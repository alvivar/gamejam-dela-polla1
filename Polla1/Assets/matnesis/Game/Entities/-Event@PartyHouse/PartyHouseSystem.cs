using UnityEngine;

public class PartyHouseSystem : MonoBehaviour
{
    Rin rin;
    Cattleya cattleya;
    MainMessage message;
    SoundClip knock;
    Transform player;

    void Update()
    {
        if (!rin)
            rin = EntitySet.Rins.Elements[0];

        if (!cattleya)
            cattleya = EntitySet.Cattleyas.Elements[0];

        if (!message)
            message = EntitySet.MainMessages.Elements[0];

        if (!knock)
            knock = EntitySet.SoundClips.Filter(x => x.id == "KnockKnock", first : true).Elements[0];

        if (!player)
            player = EntitySet.VoidCams.Elements[0].transform;

        var partyHouses = EntitySet.PartyHouses;
        for (int i = 0; i < partyHouses.Length; i++)
        {
            var partyHouse = partyHouses.Elements[i];

            if (partyHouse.state == PartyHouse.State.Idle)
                continue;

            if (partyHouse.state == partyHouse.lastState)
                continue;

            if (partyHouse.state == PartyHouse.State.SetUpGirlAtDoor)
            {
                this.tt("SetUpGirlAtDoor").Add(() =>
                    {
                        message.mainDamp = 10;
                        message.showMain = true;
                        message.main.text = "\t\tknock";

                        knock.once = true;
                    })
                    .Add(0.5f, () =>
                    {
                        message.main.text = "\t\t\tknock";
                    })
                    .Add(0.5f, () =>
                    {
                        message.main.text = "";
                    })
                    .Add(0.5f, () =>
                    {
                        partyHouse.animator.enabled = true;
                        rin.state = Rin.State.AtTheDoor;
                        cattleya.state = Cattleya.State.AtTheDoor;

                        message.main.text = "\t\tYou hear whispers\n\n";
                    })
                    .Add(2, () =>
                    {
                        message.main.text += "\t\tSomeone is coming";
                    })
                    .Add(1, () =>
                    {
                        // @todo Probably a female voice
                        message.mainDamp = 1;
                        message.main.text = "\t\t\"Yes?\"";
                    })
                    .Add(0.5f, t =>
                    {
                        message.showMain = false;
                        partyHouse.state = PartyHouse.State.GirlAnsweringTheDoor;

                        t.self.Reset();
                    })
                    .Immutable();
            }

            if (partyHouse.state == PartyHouse.State.GirlAnsweringTheDoor)
            {
                // Look at the player basically

                rin.character.transform.LookAt(player);
                rin.character.eulerAngles = new Vector3(0, rin.character.eulerAngles.y, 0);

                cattleya.character.transform.LookAt(player);
                cattleya.character.eulerAngles = new Vector3(0, cattleya.character.eulerAngles.y, 0);

                // Turn off house hidding

                var hideOnEye = EntitySet.GetHideOnEye(EntitySet.PartyHouseHides.Elements[0]);
                hideOnEye.update = false;
            }
        }
    }
}