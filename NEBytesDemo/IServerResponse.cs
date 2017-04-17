
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEBytesDemo
{
	public interface IServerResponse
	{
		string ServerName { get; }

		string Message { get; }

		DateTime TimeStamp { get; }

		bool Success { get; }
	}
}
