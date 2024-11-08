using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using Spectre.Console;

namespace ScrTableGPT;

public static class HttpListenerTools
{
    public static void StartListening(string responseContent)
    {
        string localAddress = $"http://{GetLocalIPAddress()}:" + Data.LOCAL_PORT + "/";

        HttpListener listener = new HttpListener();
        listener.Prefixes.Add(localAddress);

        Data.ListenerData listenerData = new Data.ListenerData
        {
            Listener = listener,
            Data = responseContent
        };

        listener.Start();
        AnsiConsole.MarkupLine($"""
                                
                                [bold black on lightskyblue1] LISTENING HTTP ENDPOINT ON PORT: {Data.LOCAL_PORT}... [/]
                                
                                """);

        Thread listenerThread = new Thread(ListenForRequests);
        listenerThread.Start(listenerData);
    }
    
    public static void ListenForRequests(object data)
    {
        Data.ListenerData listenerData = (Data.ListenerData)data;
        
        HttpListener listener = listenerData.Listener;
        string rawData = listenerData.Data;

        while (true)
        {
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            response.ContentType = "text/plain";
            response.ContentEncoding = Encoding.UTF8;

            byte[] buffer = Encoding.UTF8.GetBytes(rawData);
            response.ContentLength64 = buffer.Length;
            response.OutputStream.Write(buffer, 0, buffer.Length);

            response.OutputStream.Close();
        }
    }
    
    public static string GetLocalIPAddress()
    {
        string localIP = string.Empty;

        foreach (var networkInterface in NetworkInterface.GetAllNetworkInterfaces())
        {
            if (networkInterface.OperationalStatus == OperationalStatus.Up)
            {
                foreach (var unicastAddress in networkInterface.GetIPProperties().UnicastAddresses)
                {
                    if (unicastAddress.Address.AddressFamily == AddressFamily.InterNetwork && !IPAddress.IsLoopback(unicastAddress.Address))
                    {
                        localIP = unicastAddress.Address.ToString();
                        break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(localIP))
            {
                break;
            }
        }

        return localIP;
    }
}