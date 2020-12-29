using UnityEngine;

public class PartyHouseSystem : MonoBehaviour
{
    Rin rin;
    MainMessage message;
    SoundClip knock;

    float timer;

    void Update()
    {
        if (!rin)
            rin = EntitySet.Rins.Elements[0];

        if (!message)
            message = EntitySet.MainMessages.Elements[0];

        if (!knock)
            knock = EntitySet.SoundClips.Filter(x => x.id == "KnockKnock", first : true).Elements[0];

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

                        message.main.text = "\t\tMaybe this one is enough?";
                    })
                    .Add(2, t =>
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
                partyHouse.lastState = partyHouse.state;
                Debug.Log($"Girl at the door at {Time.time}");
            }
        }
    }
}