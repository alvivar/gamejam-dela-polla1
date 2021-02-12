using System;
using UnityEngine;

public class BiteUserData : MonoBehaviour
{
    public string app = "EyeOfMinds";
    public string id = "";
    public string _name = "";
    public int timePlayed = 0;
    public long lastEpoch = 0;
    public long startedEpoch = 0;

    private Bite bite;

    private float timer = 3;
    private bool firstResponse = false;

    void Start()
    {
        bite = new Bite("142.93.180.20", 1984);

        bite.OnError = OnError;
        bite.OnResponse = OnResponse;

        id = SystemInfo.deviceUniqueIdentifier;
    }

    void Update()
    {
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
    }

    void OnError(string error) { Debug.Log($"{error}"); }

    void OnResponse(string response)
    {
        Debug.Log($"> {response}");

        if (!firstResponse)
        {
            firstResponse = true;

            Load();

            SaveOrLoadStartedEpoch();
        }
    }

    void Load()
    {
        bite.Send($"g {app}.{id}.name", response =>
        {
            if (response.Trim().Length < 1)
                response = "?";

            _name = response;
        });

        bite.Send($"g {app}.{id}.timePlayed", response =>
        {
            int num = 0;
            timePlayed = int.TryParse(response, out num) ? num : 0;
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

    void SaveOrLoadStartedEpoch()
    {
        var key = $"{app}.{id}.startedEpoch";

        bite.Send($"g {key}", response =>
        {
            long num;
            startedEpoch = long.TryParse(response, out num) ? num : 0;

            if (startedEpoch <= 0)
            {
                startedEpoch = DateTimeOffset.Now.ToUnixTimeSeconds();
                bite.Send($"s {key} {startedEpoch}");
            }
        });
    }

    void SetName(string name)
    {
        this._name = name;
        bite.Send($"s {app}.{id}.name {this._name}");
    }
}