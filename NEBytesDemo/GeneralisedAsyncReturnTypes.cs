using static System.Diagnostics.Trace;
using System.Threading.Tasks;

namespace NEBytesDemo
{
	public class GeneralisedAsyncReturnTypes
	{
		public static async void Run()
		{
			{
				// First you must install a new package.
				// PM> install-package System.Threading.Tasks.Extensions

				// This grants access to a new type: ValueTask<>
			}

			{
				// Async methods only allow you to return Task, Task<T> and void

				// Currently we have.
				Task<int> myFuncTask = MyFuncAsync();

				// Do some work
				System.Threading.Thread.Sleep(300);

				WriteLine("Result = " + await myFuncTask);
			}

			{
				// We can now return types of ValueTask<T>

				ValueTask<int> myFuncTask = MyFuncAsync2();

				// Do some work
				System.Threading.Thread.Sleep(300);

				WriteLine("Result = " + await myFuncTask);
			}

			{
				// This has been introduced as an optimisation

				// Using Task in certain situations can cause a bottleneck
				// as it means allocating an object.

				// It maybe quicker in certain situations to use ValueTask<T>

			}
		}

		private static async Task<int> MyFuncAsync()
		{
			// Simulate work
			await Task.Delay(200);

			return 99;
		}
		private static async ValueTask<int> MyFuncAsync2()
		{
			// Simulate work
			await Task.Delay(200);

			return 101;
		}
	}
}
