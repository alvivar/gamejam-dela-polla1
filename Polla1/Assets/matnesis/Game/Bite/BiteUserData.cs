using UnityEngine;

public class BiteUserData : MonoBehaviour
{
    private Bite bite;

    private string app = "EyeOfMinds";
    private string id = SystemInfo.deviceUniqueIdentifier;

    private string username = "";
    private int timePlayed = 0;

    private float timer = 0;

    void Start()
    {
        bite = new Bite("142.93.180.20", 1984);

        bite.OnError = OnError;
        bite.OnResponse = OnResponse;

        Load();
    }

    void Update()
    {
        if (Time.time < timer)
            return;
        timer = Time.time + 1; // Save every second.

        timePlayed += 1;

        Save();
    }

    void Load()
    {
        bite.Send($"g {app}.{id}.name", response =>
        {
            if (response.Trim().Length < 1)
                response = "?";

            username = response;
        });

        bite.Send($"g {app}.{id}.timePlayed", response =>
        {
            var n = 0;
            timePlayed = int.TryParse(response, out n) ? n : 0;
        });
    }

    void Save()
    {
        bite.Send($"s {app}.{id}.timePlayed {timePlayed}");
    }

    void SetName(string name)
    {
        username = name;
        bite.Send($"s {app}.{id}.name {username}");
    }

    void OnResponse(string response)
    {
        Debug.Log($"> {response}");
    }

    void OnError(string error)
    {
        Debug.Log($"Error!\n{error}");
    }
}