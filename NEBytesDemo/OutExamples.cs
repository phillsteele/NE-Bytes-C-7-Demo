using System;
using static System.Diagnostics.Trace;

namespace NEBytesDemo
{
	public static class OutExamples
	{
		public static void Run()
		{
			{
				// Old way
				string myResponse;

				bool success = Connector.TryConnect(out myResponse);

				WriteLine(myResponse);
			}

			{
				// New way
				bool success = Connector.TryConnect(out string myResponse);

				WriteLine(myResponse);
			}

			{
				// New way
				bool success1 = Connector.TryConnect(out Server1Response myResponse1);

				WriteServerResponse(myResponse1);

				bool success2 = Connector.TryConnect(out Server2Response myResponse2);

				WriteServerResponse(myResponse2);
			}

			// One way of dealing with failed connection attempts
			{
				IServerResponse response = null;

				try
				{
					response = Connector.Connect("server1");

					if (response.Success)
					{
						DoSomething(response);
					}
				}
				catch (Exception)
				{
					HandleTheError(response);
				}
			}

			// Using the try pattern
			{
				if (Connector.TryConnect(out Server1Response myResponse1))
				{
					DoSomething(myResponse1);
				}
				else
				{
					HandleTheError(myResponse1);
				}
			}
		}

		private static void DoSomething(IServerResponse response)
		{
		}

		private static void HandleTheError(IServerResponse response)
		{
		}

		private static void WriteServerResponse(IServerResponse response)
		{
			WriteLine("Server=" + response.ServerName + " : " + response.Message);
		}

	}
}
