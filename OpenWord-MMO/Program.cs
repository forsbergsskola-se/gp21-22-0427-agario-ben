using System.Net;
using System.Net.Sockets;
using System.Text;

var serverEndPoint = new IPEndPoint(IPAddress.Loopback, 1138);

var server = new UdpClient(serverEndPoint);

while (true) {
	IPEndPoint clientEndpoint = default;
	var clientData = server.Receive(ref serverEndPoint);
	var clientMessage = Encoding.ASCII.GetString(clientData);

	Console.WriteLine($"Packet received from: {clientEndpoint} saying: {clientMessage}");

	if (clientData.Length is 0 or > 20 || clientMessage.Any(char.IsWhiteSpace)) {
		var exception = Encoding.ASCII.GetBytes("Whoops! Message is either over 20 characters or contains spaces. Try again!");
		server.Send(exception, clientEndpoint);
	}
	else {
		Console.WriteLine("Message Accepted!");
		var message = clientMessage + " ";
		var serverMessageData = Encoding.ASCII.GetBytes(message);
		server.Send(serverMessageData, clientEndpoint);
	}
}