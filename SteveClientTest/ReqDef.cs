using System;

namespace SteveClientTest
{
	public class ReqDef
	{
		public ReqDef ()
		{
			msg = "reqdef";
		}

		public String msg {
			get {
				return m_msg;
			}
			set {
				m_msg = value;
			}
		}

		public String id {
			get {
				return m_id;
			}
			set {
				m_id = value;
			}
		}

		private String m_msg;
		private String m_id;
	}
}

