using System;

namespace SteveClientCore
{
	public class QueryResult
	{
		public QueryResult ()
		{
			msg = "qry";
			cnt = new QueryCnt ();
		}

		public QueryResult (string c)
		{
			msg = "qry";
			cnt = new QueryCnt (c);
		}

		//{"msg":"qry","cnt":query()}
		public String msg { get; set; }
		public QueryCnt cnt{ get; set; }


	}
}

