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
			ttl = 23;
			cnt = new List<RequestCnt>();
		}

		public Request(bool socket)
		{
			msg = "comp";
			needsock = socket;
			ttl = 2;
			cnt = new List<RequestCnt>();
			/*
				{"name":"task","val":"run"},
        		{"name":"desire","val":"out"},
        		{"name":"exec","val":"python"} 
			 */
			cnt.Add (new RequestCnt ("task", new List<String>(){"run"}));
			cnt.Add (new RequestCnt ("desire", new List<String>(){"all"}));
			cnt.Add (new RequestCnt ("exec", new List<String>(){"python"}));
			//cnt.Add (new RequestCnt ("os", new List<String>(){"osx", "linux"}));
		}

		public String msg { get; set; }
		public Boolean needsock { get; set; }
		public int ttl { get; set;}
		public List<RequestCnt> cnt { get; set; }
	}
}

