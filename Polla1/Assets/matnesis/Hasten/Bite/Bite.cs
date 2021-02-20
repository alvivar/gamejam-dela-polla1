using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;

// To connect.

// Bite bite = new Bite("127.0.0.1", 1984);

// To send.

// bite.Send("s author Andrés Villalobos");
// bite.Send("j author");

// You can use a System.Action callback on send to deal directly with the response.

// bite.Send("g author", response => {
//     // Handle your response.
// });

// You also have a couple System.Action to subscribe.

// bite.OnResponse += YourOnResponse;
// bite.OnError += YourOnError;

// That's it!

public class Bite
{
    public Action<string> OnResponse;
    public Action<string> OnError;

    private List<string> messages = new List<string>();
    private List<Action<string>> callbacks = new List<Action<string>>();

    private TcpClient tcpClient;
    private Thread thread;
    private NetworkStream stream;

    private bool allowThread = false;

    private string host;
    private int port;

    public Bite(string host, int port)
    {
        this.host = host;
        this.port = port;

        StartConnectionThread();
    }

    public void Stop()
    {
        allowThread = false;

        tcpClient.Close();
    }

    public void Send(string message, Action<string> callback = null)
    {
        if (tcpClient == null || !tcpClient.Connected)
        {
            if (OnError != null)
                OnError($"Disconnected trying {message}");

            return;
        }

        messages.Add(message);
        callbacks.Add(callback);
    }

    private void StartConnectionThread()
    {
        try
        {
            allowThread = true;

            thread = new Thread(new ThreadStart(HandleConnection));
            thread.IsBackground = true;
            thread.Start();
        }
        catch (Exception e)
        {
            if (OnError != null)
                OnError($"{e}");
        }
    }

    private void HandleConnection()
    {
        try
        {
            tcpClient = new TcpClient(host, port);
            stream = tcpClient.GetStream();

            while (allowThread)
            {
                if (messages.Count <= 0 || callbacks.Count <= 0)
                    continue;

                var reader = new StreamReader(stream);
                var writer = new StreamWriter(stream);

                // Send

                var msg = messages[0];
                messages.RemoveAt(0);

                var call = callbacks[0];
                callbacks.RemoveAt(0);

                writer.WriteLine(msg);
                writer.Flush();

                // Receive

                var isSub = msg.Trim().ToLower().StartsWith("#");

                do
                {
                    var response = reader.ReadLine();

                    if (call != null)
                        call(response);

                    if (OnResponse != null)
                        OnResponse(response);
                }
                while (isSub && allowThread);
            }
        }
        catch (Exception e)
        {
            Stop();

            if (OnError != null)
                OnError($"{e}");
        }
    }

    public static int Int(string str, int or)
    {
        int n;
        return int.TryParse(str, out n) ? n : or;
    }

    public static float Float(string str, float or)
    {
        float n;
        return float.TryParse(str, out n) ? n : or;
    }

    public static long Long(string str, long or)
    {
        long n;
        return long.TryParse(str, out n) ? n : or;
    }
}