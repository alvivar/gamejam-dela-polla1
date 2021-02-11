using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class TCPTestClient : MonoBehaviour
{
    public bool messageSended = false;
    public List<string> messages;

    private TcpClient socketConnection;
    private Thread clientReceiveThread;

    void Start()
    {
        ConnectToTcpServer();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SendMessage();
        }
    }

    private void ConnectToTcpServer()
    {
        try
        {
            clientReceiveThread = new Thread(new ThreadStart(ListenForData));
            clientReceiveThread.IsBackground = true;
            clientReceiveThread.Start();
        }
        catch (Exception e)
        {
            Debug.Log("On client connect exception " + e);
        }
    }

    private void ListenForData()
    {
        try
        {
            socketConnection = new TcpClient("142.93.180.20", 1984);
            while (true)
            {
                if (!messageSended)
                    continue;

                Debug.Log($"Doint it!");

                using(NetworkStream stream = socketConnection.GetStream())
                {
                    StreamReader reader = new StreamReader(stream);

                    var incommingData = reader.ReadLine();

                    Debug.Log("server message received as: " + incommingData);
                }

                messageSended = false;
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }

    private void SendMessage()
    {
        if (socketConnection == null)
        {
            return;
        }

        try
        {
            NetworkStream stream = socketConnection.GetStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.AutoFlush = true;

            if (stream.CanWrite)
            {
                string clientMessage = "This is a message from one of your clients.";
                writer.WriteLine(clientMessage);
                Debug.Log("Client sent his message - should be received by server");
                messageSended = true;
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }
}