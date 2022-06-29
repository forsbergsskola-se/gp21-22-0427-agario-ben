using System.Net;
using System.Net.Sockets;
using System.Text;
using TMPro;
using UnityEngine;

public class RequestServerTime : MonoBehaviour {
	public TextMeshProUGUI text;
	public void SendRequest() { 
		var tcpClient = new TcpClient(new IPEndPoint(IPAddress.Loopback, 1135));
		tcpClient.Connect(new IPEndPoint(IPAddress.Loopback, 1136));
		Debug.Log("Connected!");
		var stream = tcpClient.GetStream();
		
		byte[] buffer = new byte[100];
		stream.Read(buffer, 0, 100);
		Debug.Log(Encoding.ASCII.GetString(buffer));
		text.text = Encoding.ASCII.GetString(buffer);
	}
}
