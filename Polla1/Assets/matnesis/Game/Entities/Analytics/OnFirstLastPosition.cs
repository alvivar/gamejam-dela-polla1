using System;
using UnityEngine;

public class OnFirstLastPosition : MonoBehaviour
{
    public Vector3 lastPosition;

    [Header("Required")]
    public Analytics analytics;

    [Header("Internal")]
    public VoidPlayer player;
    public MainMessage message;

    private bool updatePlayerPosWithOnline = false;
    private bool allowPlayerPosSaving = false;

    void Start()
    {
        if (!player)
            player = EntitySet.VoidPlayers.Elements[0];

        if (!message)
            message = EntitySet.MainMessages.Elements[0];

        this.tt()
            .Wait(() => analytics.data.lastPosition != Vector3.zero, 1)
            .Add(() =>
            {
                message.mainDamp = 10;
                message.main.text = "";
                message.showMain = true;
            })
            .Add(0.1f, () =>
            {
                player.fps.enabled = false;
                player.transform.position = lastPosition = analytics.data.lastPosition;
            })
            .Add(0.1f, () =>
            {
                message.mainDamp = 10f;
                message.showMain = false;

                player.fps.enabled = true;
                allowPlayerPosSaving = true;
            });
    }
}