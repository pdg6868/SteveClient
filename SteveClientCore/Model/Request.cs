using System;
using System.Collections.Generic;

namespace SteveClientCore
{
	public class Request
	{
		public Request ()
		{
			msg = "comp";
			needsock = false;
			cnt = new List<string>();
		}

		public Request(bool socket)
		{
			msg = "comp";
			needsock = socket;
			cnt = new List<string>();
		}

		public String msg { get; set; }
		public Boolean needsock { get; set; }
		public List<String> cnt { get; set; }
	}
}

