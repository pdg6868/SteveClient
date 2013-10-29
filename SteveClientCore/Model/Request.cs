using System;

namespace SteveClientCore
{
	public class Request
	{
		public Request ()
		{
			msg = "comp";
		}

		public String msg { get; set; }
		public Boolean needsock { get; set; }
	}
}

