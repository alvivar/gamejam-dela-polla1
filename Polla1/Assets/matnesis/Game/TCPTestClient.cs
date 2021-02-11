using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

public class TCPTestClient : MonoBehaviour
{
    public List<string> messages = new List<string>();

    private TcpClient socketConnection;
    private Thread clientServerThread;
    private NetworkStream stream;

    void Start() { ConnectToTcpServer(); }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Send("j");
        }
    }

    private void ConnectToTcpServer()
    {
        try
        {
            clientServerThread = new Thread(new ThreadStart(ListenForData));
            clientServerThread.IsBackground = true;
            clientServerThread.Start();
        }
        catch (Exception e)
        {
            Debug.Log($"ConnectToTcpServer exception:\n{e}");
        }
    }

    private void ListenForData()
    {
        try
        {
            socketConnection = new TcpClient("142.93.180.20", 1984);
            stream = socketConnection.GetStream();

            while (true)
            {
                if (messages.Count <= 0)
                    continue;

                var reader = new StreamReader(stream);
                var writer = new StreamWriter(stream);

                var message = messages[0];
                messages.RemoveAt(0);

                writer.WriteLine(message);
                writer.Flush();
                Debug.Log($"Sent:\n{message}");

                var response = reader.ReadLine();
                Debug.Log("Received:\n" + response);
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log($"ListenForData exception:\n{socketException}");
        }
    }

    private void Send(string message)
    {
        if (socketConnection == null || !socketConnection.Connected)
        {
            Debug.Log($"Socket disconnected.");
            return;
        }

        messages.Add(message);
    }
}