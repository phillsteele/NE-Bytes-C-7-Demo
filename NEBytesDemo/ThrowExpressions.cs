using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Diagnostics.Trace;

namespace NEBytesDemo
{
	public static class ThrowExpressions
	{
		public static void Run()
		{
			{
				// Because throw has always been a statement there are places in C# that you
				// could not use it before.

				// The addition of expression-bodied members has added to the number of places
				// where throw expressions would be useful.

				// C#7 introduces throw expressions.
			}


			// Allowed as the 2nd operator of ??
			{
				// Consider the old way
				try
				{
					string x = GetName() ?? ThrowNullNotAllowed();
				}
				catch (Exception ex) { WriteLine(ex.Message); }

				// This can now be replaced by
				try
				{
					string y = GetName() ?? throw new ArgumentNullException();
				}
				catch (Exception ex) { WriteLine(ex.Message); }
			}

			// and the 2nd and 3rd operator of ?:
			{
				try
				{
					string y = GetName();
					string x = y == null ? throw new ArgumentNullException() : y;
				}
				catch (Exception ex) { WriteLine(ex.Message); }
			}

			// and within expression bodies.
			{
				try
				{
					DoStuff(null);
				}
				catch (Exception ex) { WriteLine(ex.Message); }

			}
		}

		private static string GetName()
		{
			return null;
		}

		private static string ThrowNullNotAllowed()
		{
			throw new ArgumentNullException();
		}

		private static string DoStuff(string x) => x ?? throw new ArgumentNullException(nameof(x));
	}
}
