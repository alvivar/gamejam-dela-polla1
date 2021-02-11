using System;
using System.Collections;
using System.IO;
using System.Net.Sockets;
using UnityEngine;

public class Bite
{
    private TcpClient tcp;
    private StreamWriter writer;
    private StreamReader reader;

    private string host;
    private int port;

    public Bite(string host, int port)
    {
        this.host = host;
        this.port = port;

        Connect(host, port);
    }

    void Connect(string host, int port)
    {
        tcp = new TcpClient(host, port);
        writer = new StreamWriter(tcp.GetStream());
        reader = new StreamReader(tcp.GetStream());
    }

    public IEnumerator Set(string key, string value, Action<string> OnSet)
    {
        try
        {
            writer.WriteLine($"s {key} {value}");
            var response = reader.ReadLine();

            if (OnSet != null)
                OnSet(response);
        }
        catch (Exception ex)
        {
            Debug.Log($"{ex} at {Time.time}");

            if (OnSet != null)
                OnSet(ex.ToString());
        }

        yield return null;
    }
}