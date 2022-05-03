using System.Net;
using System.Net.Sockets;

public static class Program {
	static void Main() { 
		var tcpListener = new TcpListener(IPAddress.Any, 1136);
		tcpListener.Start();
		
		while (true) {
			Console.WriteLine("Waiting for connection...");
			var tcpClient = tcpListener.AcceptTcpClient();
			new Thread(() => {
					Console.WriteLine($"Client {tcpClient.Client.RemoteEndPoint} connected!");
					
					var stream = tcpClient.GetStream();
					
					var streamReader = new StreamReader(stream);
					
					var streamWriter = new StreamWriter(stream);
					streamWriter.AutoFlush = true;
					while (true) {
						streamWriter.Write("Do you want the date and time? (Y/N/Meow)");
						var input = streamReader.ReadLine();
						if (input == "N") {
							streamWriter.WriteLine("Bye!");
							Console.WriteLine("Said Bye!");
							break;
						}
						switch (input) {
							case "Y":
								streamWriter.WriteLine($"Time: {DateTime.Now}");
								Console.WriteLine($"Sent: {DateTime.Now}");
								break;
							default:
								streamWriter.WriteLine(GenerateCatFact());
								Console.WriteLine("Cat fact sent!");
								break;
						}
					}
					tcpClient.Dispose();
				}
			).Start();
		}
		string GenerateCatFact() {
			var random = new Random();
			
			switch (random.Next(0, 8)) {
				case 0:
					return "Cats conserve energy by sleeping for an average of 13 to 14 hours a day.";
				case 1:
					return "The heaviest domestic cat on record is 21.297 kilograms";
				case 2:
					return "Cats spend a large amount of time licking their coats to keep them clean.";
				case 3:
					return "Cats have flexible bodies and teeth adapted for hunting small animals such as mice and rats.";
				case 4:
					return "Cats also have excellent hearing and a powerful sense of smell.";
				case 5:
					return "On average cats live for around 12 to 15 years.";
				case 6:
					return "There are over 500 million domestic cats in the world.";
				default:
					return "A group of cats is called a clowder, a male cat is called a tom, a female cat is called a molly or queen while young cats are called kittens.";
			}
			
		}
	}
}
