using System;

namespace SteveClientCore
{
	public class ReqResp
	{
		public ReqResp ()
		{
			msg = "comp";
			id = "";
		}

		//{"msg":"comp","cid":string()}

		public String msg { get; set; }
		public String id { get; set; }
	}
}

