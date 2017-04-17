using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEBytesDemo
{
	public class Server1Response : IServerResponse
	{
		public string ServerName { get { return "Acme Mainframe 1"; } }
		public string Message { get { return "Welcome to Acme Labs, MOTD: Remember to be safe when playing with fire";  } }
		public DateTime TimeStamp { get { return DateTime.Now; } }
		public bool Success {  get { return true; } }
	}
}
