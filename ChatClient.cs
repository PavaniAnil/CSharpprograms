using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class ClientSocket
{
    public static void Main(string[] args)
    {
        var serverIP = "192.168.1.53";
        var serverPort = 5389;
        var client = new TcpClient();
        client.Connect(serverIP, serverPort);
        var stream = client.GetStream();

        while (true)
        {
            Console.Write("Enter message: ");
            var message = Console.ReadLine();
            var messageBytes = Encoding.UTF8.GetBytes(message);
            stream.Write(messageBytes, 0, messageBytes.Length);
            if (message.ToLower() == "bye")
            {
                break;
            }
            var buffer = new byte[1024];
            var bytesRead = stream.Read(buffer, 0, buffer.Length);
            var serverMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Server: " + serverMessage);
        }

        client.Close();
    }
}







/*// client socket for chat with only single message.

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;


class ClientSocket
{
	public static void Main(string[] args)
	{
		var serverIP = "192.168.1.53";
		var serverPort = 5389;

		// Console.WriteLine(">>>")
		var message = "Hello";

		var client = new TcpClient();
		client.Connect(serverIP, serverPort);

		var stream = client.GetStream();
		var messageBytes = Encoding.UTF8.GetBytes(message);
		stream.Write(messageBytes, 0, messageBytes.Length);

		Console.WriteLine("Sent Message: " + message);
	}
}*/










