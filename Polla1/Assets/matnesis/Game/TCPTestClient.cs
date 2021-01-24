using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class TCPTestClient : MonoBehaviour
{
    private TcpClient socketConnection;
    private Thread clientReceiveThread;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            using(TcpClient tcpClient = new TcpClient())
            {
                try
                {
                    tcpClient.Connect("localhost", 1984);

                    StreamWriter writer = new StreamWriter(tcpClient.GetStream());
                    writer.AutoFlush = true;

                    writer.WriteLine("set adros 1984");
                    writer.WriteLine("set uno 1984");
                    writer.WriteLine("set dos 1984");
                    writer.WriteLine("set tres 1984");

                    StreamReader reader = new StreamReader(tcpClient.GetStream());
                    var result = reader.ReadLine();
                    Debug.Log(result);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.ToString());
                }
            }
        }
    }
}