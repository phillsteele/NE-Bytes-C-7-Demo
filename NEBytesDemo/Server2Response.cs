using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEBytesDemo
{
	public class Server2Response : IServerResponse
	{
		public string ServerName { get { return "Acme Mini Lab 1"; } }
		public string Message { get { return "Welcome to Acme Labs, MOTD: Remember don't eat yellow snow !"; } }
		public DateTime TimeStamp { get { return DateTime.Now; } }
		public bool Success { get { return true; } }
	}
}
