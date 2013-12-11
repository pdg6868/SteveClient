using System;
using System.Collections.Generic;

namespace SteveClientCore
{
	public class RequestCnt
	{
		public RequestCnt ()
		{
			name = "os";
			//val = new List<string> ();
			//val.Add ("osx");
		}

		public RequestCnt (string n, List<String> v)
		{
			name = n;
			val = v [0];
		}

		public String name;
		//public List<String> val;
		public String val;
	}
}

