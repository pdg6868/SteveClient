using System;

namespace SteveClientCore
{
	public class QueryClients : Message
	{
		public QueryClients ()
		{
			cnt = "clients";
		}

		public String cnt { get; set; }
	}
}

