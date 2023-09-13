// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;
using System.Text;

//IPAddress ip = IPAddress.Loopback;



//Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
//IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("192.168.0.1"), 1234);

//IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("192.168.0.1"), 1234);
//socket.Bind(endPoint);
//socket.Listen(1000); //nombre de connexion simultannées
//socket.Accept(); // Bloque jusqu'a qu une connexion soit etablie


try
{
    IPAddress ip_any = IPAddress.Any;

    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

    IPEndPoint endPoint = new IPEndPoint(ip_any, 2345);

    socket.Bind(endPoint);
    socket.Listen();
    var clientSocket = socket.Accept();
    if (clientSocket.RemoteEndPoint is not null)
    {
        System.Console.WriteLine(
            "client connecté depuis :" + clientSocket.RemoteEndPoint.ToString()
        );

        while (true)
        {
            byte[] buffer = new byte[128];
            int nbROctets = clientSocket.Receive(buffer);
            System.Console.WriteLine(
                "Message recu :" + Encoding.UTF8.GetString(buffer, 0, nbROctets)
            );
        }
    }
}
catch (Exception ex)
{
    System.Console.WriteLine("une erreur est survenue");
}
