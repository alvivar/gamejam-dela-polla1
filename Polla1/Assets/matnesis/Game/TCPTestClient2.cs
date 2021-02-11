using System;
using System.IO;
using System.Net.Sockets;
using UnityEngine;

public class TCPTestClient2 : MonoBehaviour
{
    public string message;

    public Bite bite;

    void Start()
    {
        bite = new Bite("142.93.180.20", 1984);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            var key = $"user.{SystemInfo.deviceUniqueIdentifier}.test";
            var val = $"{Time.time}";

            StartCoroutine(bite.Set(key, val, OnOperation));
        }
    }

    void OnOperation(string response)
    {
        Debug.Log($"{response} at {Time.time}");
    }
}

// Debug.Log($"Socketed at {Time.time}");
// using(TcpClient tcpClient = new TcpClient())
// {
//     try
//     {
//         tcpClient.Connect("142.93.180.20", 1984);

//         StreamWriter writer = new StreamWriter(tcpClient.GetStream());
//         writer.AutoFlush = true;

//         writer.WriteLine(message);
//         message = "";
//         Debug.Log($"Sended: {message} at {Time.time}");

//         StreamReader reader = new StreamReader(tcpClient.GetStream());
//         var result = reader.ReadLine();
//         Debug.Log($"Received: {result} at {Time.time}");
//     }
//     catch (Exception ex)
//     {
//         Console.Error.WriteLine(ex.ToString());
//     }
// }