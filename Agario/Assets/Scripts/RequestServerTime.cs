using System.Net;
using System.Net.Sockets;
using System.Text;
using TMPro;
using UnityEngine;

public class RequestServerTime : MonoBehaviour {
	public TextMeshProUGUI text;
	private int count;
	public void SendRequest() {

		var tcpClient = new TcpClient(new IPEndPoint(IPAddress.Loopback, 1135));
		tcpClient.Connect(new IPEndPoint(IPAddress.Loopback, 1136));
		Debug.Log("Connected!");
		var stream = tcpClient.GetStream();

		switch (count) {
			case 0:
				byte[] buffer = new byte[100];
				stream.Read(buffer, 0, 100);
				Debug.Log(Encoding.ASCII.GetString(buffer));
				text.text = Encoding.ASCII.GetString(buffer);
				break;
				
			case 1:
				var message = Encoding.ASCII.GetBytes("Y");
				stream.Write(message, 0, message.Length);
				break;
		}
		count++;
	}
}
