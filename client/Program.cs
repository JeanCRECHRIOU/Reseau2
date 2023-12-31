﻿using System.Net;
using System.Net.Sockets;
using System.Text;

Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, 2345);

try
{
    socket.Connect(endPoint);
    while (true)
    {
        string? message = Console.ReadLine();

        if (message == "q")
        {
            break;
        }

        if (!string.IsNullOrEmpty(message))
        {
            var buffer = Encoding.UTF8.GetBytes(message);
            socket.Send(buffer);
        }
    }
}
catch
{
    System.Console.WriteLine("Le server est injoignable");
}
finally
{
    if (socket.Connected)
    {
        socket.Shutdown(SocketShutdown.Both);
    }
    socket.Close();
}
