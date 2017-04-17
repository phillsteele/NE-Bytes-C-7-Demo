using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Diagnostics.Trace;

namespace NEBytesDemo
{
	public static class LocalFunctions
	{
		public static void Run()
		{
			{
				WriteLine(GetFibonacci(4));
			}

			{
				// Local functions vs lambda expressions

				// Comparing MethodWithLocalLambda and MethodWithLocalFunction in ildasm

				// Also need to predefine lambdas before they can be used, making it difficult to use in recursion

				// Lambda functions are implemented by instantiating a delegate and invoking it
				// Local functions are implemented as method calls.
			}
		}

		// We can provide nice interfaces to methods without the need to also expose additional
		// functionality within a class where it is not required.
		public static int GetFibonacci(int length)
		{
			// Allows us to perform parameter checking and keep it seperate to the core
			if (length < 0)
				throw new ArgumentException("No negatives");

			// Or handle special cases.
			if (length == 0)
				return 0;

			int counter = 0;

			return GetFib((0,1)).current;

			// We get to hide the internals
			(int previous, int current) GetFib((int previous, int current) value)
			{
				// We have access to variables in the containing method
				if (counter < length)
				{
					counter++;
					return GetFib((value.current, value.current + value.previous));
				}
				else
				{
					return value;
				}
			}
		}

		public static int MethodWithLocalLambda(int length)
		{
			Func<int> GetValueFromLambda = () =>
			{
				return 7;
			};

			return GetValueFromLambda();
		}

		public static int MethodWithLocalFunction(int length)
		{
			return GetValueFromLocalFunction();

			int GetValueFromLocalFunction()
			{
				return 7;
			};

		}

	}
}
