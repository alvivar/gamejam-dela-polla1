using System;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class BiteUserData : MonoBehaviour
{
    public string app = "EyeOfMinds";
    public string id = "";
    public string _name = "";
    public int timePlayed = 0;
    public Vector3 lastPosition;
    public long lastEpoch = 0;
    public long startedEpoch = 0;

    [Header("Internal")]
    public VoidPlayer player;
    public MainMessage message;

    private Bite bite;

    private float timer = 3;
    private bool firstResponse = false;
    private bool updatePlayerPosWithOnline = false;
    private bool allowPlayerPosSaving = false;

    void Start()
    {
        bite = new Bite("142.93.180.20", 1984);

        bite.OnResponse = OnResponse;
        bite.OnError = OnError;

        id = SystemInfo.deviceUniqueIdentifier;
    }

    void OnDestroy() { bite.Stop(); }

    void Update()
    {
        if (!player)
            player = EntitySet.VoidPlayers.Elements[0];

        if (!message)
            message = EntitySet.MainMessages.Elements[0];

        // @todo This should be handled by a System in their own.
        if (updatePlayerPosWithOnline)
        {
            updatePlayerPosWithOnline = false;

            this.tt().Add(() =>
                {
                    message.mainDamp = 10;
                    message.main.text = "";
                    message.showMain = true;
                })
                .Add(0.1f, () =>
                {
                    player.fps.enabled = false;
                    player.transform.position = lastPosition;
                })
                .Add(0.1f, () =>
                {
                    message.mainDamp = 10f;
                    message.showMain = false;

                    player.fps.enabled = true;
                    allowPlayerPosSaving = true;
                });
        }

        // Every.
        var tick = 3;

        if (Time.time < timer)
            return;
        timer = Time.time + tick;

        // Ping until server connection.
        if (!firstResponse)
        {
            bite.Send("g");
            return;
        }

        // Statistics.
        SaveTimePlayed(tick);
        SaveLastEpoch();

        if (allowPlayerPosSaving)
            SaveLastPosition();
    }

    void OnError(string error) { Debug.Log($"{error}"); }

    void OnResponse(string response)
    {
        if (!firstResponse)
        {
            Debug.Log($"Starting to sync with Bite.");
            Debug.Log($"> {response}");

            firstResponse = true;

            FirstLoad();

            LoadOrSetStartedEpoch();
        }
    }

    void FirstLoad()
    {
        bite.Send($"g {app}.{id}.name", response =>
        {
            if (response.Trim().Length < 1)
                response = "?";

            _name = response;
        });

        bite.Send($"g {app}.{id}.timePlayed", response =>
        {
            timePlayed = Bite.Int(response, 0);
        });

        bite.Send($"j {app}.{id}.lastPosition", response =>
        {
            var json = JObject.Parse(response);

            lastPosition = new Vector3(
                Bite.Float($"{json["x"]}", 0),
                Bite.Float($"{json["y"]}", 0),
                Bite.Float($"{json["z"]}", 0)
            );

            if (lastPosition.y == 0)
                return;

            updatePlayerPosWithOnline = true;
        });
    }

    void SaveTimePlayed(int time)
    {
        timePlayed += time;
        bite.Send($"s {app}.{id}.timePlayed {timePlayed}");
    }

    void SaveLastEpoch()
    {
        lastEpoch = DateTimeOffset.Now.ToUnixTimeSeconds();
        bite.Send($"s {app}.{id}.lastEpoch {lastEpoch}");
    }

    void LoadOrSetStartedEpoch()
    {
        var key = $"{app}.{id}.startedEpoch";

        bite.Send($"g {key}", response =>
        {
            startedEpoch = Bite.Long(response, 0);

            if (startedEpoch <= 0)
            {
                startedEpoch = DateTimeOffset.Now.ToUnixTimeSeconds();
                bite.Send($"s {key} {startedEpoch}");
            }
        });
    }

    void SaveLastPosition()
    {
        lastPosition = player.transform.position;

        bite.Send($"s {app}.{id}.lastPosition.x {lastPosition.x}");
        bite.Send($"s {app}.{id}.lastPosition.y {lastPosition.y}");
        bite.Send($"s {app}.{id}.lastPosition.z {lastPosition.z}");
    }

    void SetName(string name)
    {
        this._name = name;
        bite.Send($"s {app}.{id}.name {this._name}");
    }
}