using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEBytesDemo
{
	public static class Extensions
	{
		public static void Deconstruct(this System.Threading.Thread t, out string name, out bool isAlive)
		{
			name = t.Name;
			isAlive = t.IsAlive;
		}
	}
}
