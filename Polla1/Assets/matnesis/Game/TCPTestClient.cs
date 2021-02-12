using UnityEngine;

public class TCPTestClient : MonoBehaviour
{
    private Bite bite;

    void Start()
    {
        bite = new Bite("142.93.180.20", 1984);

        bite.OnError = OnError;
        bite.OnResponse = OnResponse;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bite.Send("j");
        }
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