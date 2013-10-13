using System;
using System.Net;
using System.Net.Sockets;

namespace SteveClientCore
{
	public class Communication
	{
		public Communication ()
		{
		}

		public void InitialConnection()
		{
			try
			{
				IPAddress ipAddr = IPAddress.Parse("xxx.xxx.x.xxx");
				IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 4028);

				Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				sender.Connect(ipEndPoint);
				//Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());

				string SummaryMessage = "string to send";
				byte[] msg = System.Text.Encoding.GetBytes(SummaryMessage);

				sender.Send(msg);
				byte[] buffer = new byte[1024];
				int lengthOfReturnedBuffer = sender.Receive(buffer);
				char[] chars = new char[lengthOfReturnedBuffer];

				System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
				int charLen = d.GetChars(buffer, 0, lengthOfReturnedBuffer, chars, 0);
				String returnedJson = new String(chars);
				//Console.WriteLine("The Json:{0}", returnedJson);
				sender.Shutdown(SocketShutdown.Both);
				sender.Close();        
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception: {0}", ex.ToString());
			}
		}
	}
}

