using UnityEngine;

// !Gigas
public class PartyHouseHide : MonoBehaviour
{
    private void OnEnable()
    {
        EntitySet.AddPartyHouseHide(this);
    }

    private void OnDisable()
    {
        EntitySet.RemovePartyHouseHide(this);
    }
}