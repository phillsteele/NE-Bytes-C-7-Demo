using System.Collections.Generic;
using static System.Diagnostics.Trace;

namespace NEBytesDemo
{
	public static class PattternMatchingExamples
	{
		public static void Run()
		{
			// Old suppport for is
			{
				string x = "Hi there";

				if (x is string)
				{
					WriteLine(x);
				}
			}

			// Now extended to support pattern matching

			// Type pattern - here we match against a type
			{
				foreach (var item in GetList())
				{
					// As part of the type checking a new variable is also initialised
					if (item is decimal amount)
					{
						amount = amount * 100;

						WriteLine("Amount is: " + amount.ToString());
					}
					else if (item is string someText)
					{
						someText = "XXX" + someText;

						WriteLine(someText);
					}
				}
			}

			{
				// Pattern matching also works with nullable types
				int? x = 3;

				if (x is int y)
				{
					WriteLine(y);
				}
			}

			// Pattern matching has also been added to switch statements, so the above now looks like
			{
				foreach (var item in GetList())
				{
					// The is keyword now both tests and assigns the variable
					// to a new variable of the correct type
					switch (item)
					{
						case decimal amount:
							amount = amount * 100;
							WriteLine("Amount is: " + amount.ToString());
							break;

						case string someText:
							someText = "XXX" + someText;
							WriteLine(someText);
							break;
					}
				}

				// Useful where the types are completely different
			}

			// We can also mix in suppport for constants and nulls
			{
				foreach (var item in GetList2())
				{
					// As part of the type checking a new variable is also initialised
					switch (item)
					{
						case 0m:
							// We will not do anything with 0 values.
							break;

						case decimal amount:
							amount = amount * 100;
							WriteLine("Amount is: " + amount.ToString());
							break;

						case string someText:
							someText = "XXX" + someText;
							WriteLine(someText);
							break;

						case null:
							//throw new ArgumentException(paramName: nameof(item), message: "Must not be null");
							break;
					}

					// The order is important, changing "case 0m" with "case decimal amount" will give a compile error
				}
			}


			// We can add suppport for special cases using the when keyword
			{
				foreach (var item in GetList3())
				{
					// As part of the type checking a new variable is also initialised
					switch (item)
					{
						case DistrictData dd when dd.Balance > 100:
							WriteLine("Districts with more than 100: " + dd.Name);
							break;

						case DistrictData dd:
							WriteLine("Districts with less than or equal to 100: " + dd.Name);
							break;


						case decimal amount:
							amount = amount * 100;
							WriteLine("Amount is: " + amount.ToString());
							break;

						case string someText:
							someText = "XXX-" + someText;
							WriteLine(someText);
							break;
					}
				}
			}

			{
				// Tuples cannot be pattern matched.
				string name1 = "John Smith";
				var areEqual1 = name1 is string otherName1;

				//var name2 = (FirstName: "John", SecondName: "Smith");
				//var areEqual2 = name2 is string otherName2;

				// C# designers want this to mean a recursive pattern, rather than just a tuple type.
				// They will be getting to recursive patterns in a future version.
			}

			// When to use?
			{
				// Several different types of structs that you need to perform similar operations on

				// When you have similar types that you don't want to extend by writing new methods for each type

				// More pattern matching is proposed including:
				//	Constant pattern
				//	Var pattern
				//	Discard pattern
				//	Positional pattern

				// .. to name but a few
			}
		}

		private static List<object> GetList()
		{
			List<object> list = new List<object>()
			{
				"abc",
				123m
			};
			return list;
		}

		private static List<object> GetList2()
		{
			List<object> list = new List<object>()
			{
				"abc",
				123m,
				0m,
				null
			};

			return list;
		}

		private static List<object> GetList3()
		{
			var data = new List<object>()
			{
				new DistrictData()
				{
					Balance = 100,
					ID = 1,
					Name = "District 1"
				},

				new DistrictData()
				{
					Balance = 200,
					ID = 2,
					Name = "District 2"
				},

				123m,
				"Hi there"
			};

			return data;
		}

	}
}
