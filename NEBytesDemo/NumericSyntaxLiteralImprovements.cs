using static System.Diagnostics.Trace;

namespace NEBytesDemo
{
	public static class NumericSyntaxLiteralImprovements
	{
		public static void Run()
		{
			{
				// It is now possible to use an underscore, _ , in string literals

				const long OneBillion = 1_000_000_000;
				WriteLine($"One billion = {OneBillion}");

				// This works for any type of number
				int OneHundredTwentyEight = 0b1000_0000;
				WriteLine($"OneHundredTwentyEight = {OneHundredTwentyEight}");

			}
		}
	}
}
