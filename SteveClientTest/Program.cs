using System;
using System.Net.Sockets;
using Newtonsoft.Json;
using SteveClientCore;
using System.IO;
using System.IO.Compression;
using ICSharpCode.SharpZipLib.Zip;

namespace SteveClientTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			string host = "129.21.135.90";
			int port = 51343;
			string id;

			TcpClient tcpClient = new TcpClient(host, port);

			//Setup StreamReader and StreamWriter to read and write
			NetworkStream stream = tcpClient.GetStream();
			StreamReader reader = new StreamReader(stream);
			StreamWriter writer = new StreamWriter(stream);

			//Send ReqDef
			writer.Write (JsonConvert.SerializeObject(new ReqDef ()) + "\n");
			writer.Flush ();

			Console.WriteLine ("Sent ReqDef");

			string resp = reader.ReadLine ();

			ReqDefResp reqDefResp = JsonConvert.DeserializeObject<ReqDefResp> (resp);

			Console.WriteLine ("Recieved ReqDefResp");
			id = reqDefResp.id;

			//Send Request
			string toWrite = JsonConvert.SerializeObject (new Request (true)) + "\n";
			writer.Write (toWrite);
			writer.Flush();

			Console.WriteLine ("Sent Request");

			string req1 = reader.ReadLine ();
			ReqResp reqResp = JsonConvert.DeserializeObject<ReqResp> (req1);

			Console.WriteLine ("Recieved RequestResp");

			TFTPClient client = new TFTPClient (reqResp.port, host);
			//TFTPClient client = new TFTPClient (51950, host);

			//FileStream file = File.Create (reqResp.cid + ".zip");
			//Directory.CreateDirectory ("test");
			StreamWriter file = new StreamWriter (reqResp.cid + ".zip");
			file.WriteLine ("This is a test");
			file.Close ();

			client.PutFile (reqResp.cid + ".zip");
			//client.PutFile ("foo.zip");
			Console.WriteLine ("File Sent");
			//Keep going...

			if (tcpClient != null)
			{
				try
				{
					tcpClient.Close();
				}
				catch (Exception e)
				{
					Console.WriteLine("Socket Couldnt be closed with message: " + e.Message);
					Environment.Exit(0);
				}
			}


		}
	}
}
