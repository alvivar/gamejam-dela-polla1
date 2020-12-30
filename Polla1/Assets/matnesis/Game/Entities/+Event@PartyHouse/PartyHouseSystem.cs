using UnityEngine;

public class PartyHouseSystem : MonoBehaviour
{
    Rin rin;
    Cattleya cattleya;
    MainMessage message;
    SoundClip knock;
    Transform player;

    float timer;

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
            player = EntitySet.VoidPlayers.Elements[0].transform;

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
                        message.main.text = "\t\t*knock knock*";
                        message.showMain = true;

                        knock.once = true;
                    })
                    .Add(1, () =>
                    {
                        partyHouse.animator.enabled = true;
                        rin.state = Rin.State.AtTheDoor;
                        cattleya.state = Cattleya.State.AtTheDoor;

                        message.main.text = "\t\t\t\t(Maybe this one is enough?)";
                    })
                    .Add(3, t =>
                    {
                        message.main.text = "";
                        message.showMain = false;
                        partyHouse.state = PartyHouse.State.GirlAnsweringTheDoor;

                        t.self.Reset();
                    })
                    .Immutable();
            }

            if (partyHouse.state == PartyHouse.State.GirlAnsweringTheDoor)
            {
                // partyHouse.lastState = partyHouse.state;

                rin.character.transform.LookAt(player);
                rin.character.eulerAngles = new Vector3(0, rin.character.eulerAngles.y, 0);

                cattleya.character.transform.LookAt(player);
                cattleya.character.eulerAngles = new Vector3(0, cattleya.character.eulerAngles.y, 0);
            }
        }
    }
}