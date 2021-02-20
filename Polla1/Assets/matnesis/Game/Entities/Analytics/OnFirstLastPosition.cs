using UnityEngine;

public class OnFirstLastPosition : MonoBehaviour
{
    public Vector3 lastPosition;

    [Header("Required")]
    public Analytics analytics;

    [Header("Internal")]
    public VoidPlayer player;
    public MainMessage message;

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
                player.fps.enabled = false;
            })
            .Add(0.7f, () =>
            {
                player.transform.position = lastPosition = analytics.data.lastPosition;
            })
            .Add(0.3f, () =>
            {
                message.showMain = false;
                player.fps.enabled = true;
            });
    }
}