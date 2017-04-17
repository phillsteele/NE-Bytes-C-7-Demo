
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEBytesDemo
{
	public static class Connector
	{
		public static bool TryConnect(out string response)
		{
			response = "Welcome, you are connected to Acme Labs research computer";

			return true;
		}

		public static bool TryConnect<T>(out T response) where T : IServerResponse, new()
		{
			response = new T();

			return true;
		}

		public static IServerResponse Connect(string serverName)
		{
			if (serverName == "server1")
			{
				return new Server1Response();
			}
			else if (serverName == "server2")
			{
				return new Server2Response();
			}
			else
			{ 
				throw new Exception("Server not found");
			}
		}
	}
}
