using System;
using System.Net.Sockets;
using Newtonsoft.Json;
using SteveClientCore;
using System.IO;
using System.IO.Compression;
using ICSharpCode.SharpZipLib.Zip;
using System.Threading;

namespace SteveClientTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			string host = "localhost";
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

			string foo = reader.ReadLine ();

			writer.Write (foo.Replace ("CompAck", "CompAccept") + "\n");
			writer.Flush ();

			TFTPClient client = new TFTPClient (reqResp.port, host);
			//TFTPClient client = new TFTPClient (51950, host);

			//FileStream file = File.Create (reqResp.cid + ".zip");
			//Directory.CreateDirectory ("test");
			//StreamWriter file = new StreamWriter (reqResp.cid + ".zip");
			//file.WriteLine ("This is a test");
			//file.Close ();

			System.IO.File.Copy (@"Makefile.zip", reqResp.cid + ".zip");

			client.PutFile (reqResp.cid + ".zip");
			//client.PutFile ("foo.zip");
			Console.WriteLine ("File Sent");

			string foo1 = reader.ReadLine ();
			//client.GetFile ("result_" + reqResp.cid + ".zip");

			//Disconnect
			tcpClient.Close ();
			reader.Close ();
			writer.Close ();
			stream.Close ();

			tcpClient = new TcpClient(host, port);

			//Setup StreamReader and StreamWriter to read and write
			stream = tcpClient.GetStream();
			reader = new StreamReader(stream);
			writer = new StreamWriter(stream);

			//Try Querying
			writer.WriteLine (JsonConvert.SerializeObject (new QueryResult(reqResp.cid)));
			writer.Flush ();

			string foo5 = reader.ReadLine();
			client = new TFTPClient (reqResp.port, host);
			client.GetFile ("result_" + reqResp.cid + ".zip");

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
