using System;
using System.Collections.Generic;
using static System.Diagnostics.Trace;
using System.Linq;

namespace NEBytesDemo
{
	public static class TupleExamples
	{
		public static void Run()
		{
			// Old way
			{
				var district = Tuple.Create<string, string>("Newcastle", "Heaton");
				var temperatues = Tuple.Create<decimal, decimal, decimal, decimal>(23.5m, -12.1m, 12.4m, 99m);
				var racePosition = Tuple.Create<string, int>("Mo Farah", 1);

				// Not obvious what Item1 and Item2 are
				WriteLine($"{district.Item1} : {district.Item1}");
				WriteLine($"{racePosition.Item1} : {racePosition.Item1}");

				// Need a Tuple bigger than 8 fields, then things get messy
				var upTo8letters = Tuple.Create<string, string, string, string, string, string, string, string>
					("a", "b", "c", "d", "e", "f", "g", "h");

				// Even messier if you need to go higher than 8 fields
				var upTo10Letters = Tuple.Create<string, string, string, string, string, string, string,
					Tuple<string, string, string>>
					("a", "b", "c", "d", "e", "f", "g", new Tuple<string, string, string>("h", "i", "j"));

				// You can of course define your own types -- but this leads to lots of class defintions
				// in your code when they may only have a very limited scope of usage.

				MyClass mc = new MyClass() // MyClass has to be defined somewhere
				{
					FirstName = "John",
					LastName = "Smith"
				};

				// Or use anonymous types
				var myName = new
				{
					FirstName = "John",
					LastName = "Smith"
				};
			}

			// New way
			{
				// Make sure you reference System.ValueTuple

				var letters = ("a", "b");

				// Still have the old Item1, Item2 if not specified
				WriteLine($"{letters.Item1} : {letters.Item2}");

			}

			{

				// But we can name them.
				(string Name, int Position) runner = ("Mo Farah", 1);

				WriteLine($"{runner.Name} was in position: {runner.Position}");

				// Also like this....
				var tempPair = (High: 100d, Low: 32d);

				WriteLine($"High temp is: {tempPair.High}");
				WriteLine($"Low temp is: {tempPair.Low}");

				// and if you want to...

				// Generates warnings (CS8123), and ignores the High and Low names
				(string FirstName, string LastName) runnerName = (High: "Mo", Low: "Farah");

				WriteLine($"Runners name is {runnerName.FirstName} {runnerName.LastName}");
			}

			{
				// Also be careful, you can do the following and there are no compiler warnings

				// Consider ...
				(string LastName, string FirstName) name = GetName();
				WriteLine($"{name.FirstName} {name.LastName}");
			}

			{ 
				// They are not immutable.  Immutable tuples are a feature of some languages.
				var tempRange = (High: 100d, Low: 32d);

				WriteLine($"High: {tempRange.High}");

				tempRange.High = 23;

				WriteLine($"High: {tempRange.High}");
			}

			{
				// They are value types
				Type tupleType = typeof( (string Location, int x, int y) );

				WriteLine($"IsValueType={tupleType.IsValueType}");
			}

			{
				// They can be return types from a method, you can't use anonymous types in the same way
				var name = GetName();

				WriteLine($"{name.FirstName} {name.LastName}");
			}

			{
				// Types of tuples are considered to be the same if they have the same number of fields
				// and those types are identical.

				// These are equal
				bool equal = typeof((string x, int y)) == typeof((string a, int b));

				WriteLine($"Are equal = {equal}");

				// These are not
				bool notEqual1 = typeof((string x, int y, int z)) == typeof((string a, int b));

				WriteLine($"Are equal = {notEqual1}");

				bool notEqual2 = typeof((int x, string)) == typeof((string a, int b));

				WriteLine($"Are equal = {notEqual2}");
			}

			{
				// They are useful for linq support

				// Using anonymous types
				var listOfAnonymousTypes = from item in GetList()
						   where item.Balance > 250
						   orderby item.Name descending
						   select new { DistrictName = item.Name, item.ID };

				WriteLine(listOfAnonymousTypes.First().DistrictName);

				var listOfTuples = from item in GetList()
								   where item.Balance > 350
								   orderby item.Name descending
								   select (DistrictName: item.Name, item.ID) ;

				WriteLine(listOfTuples.First().DistrictName);
			}

			{
				// You can unpackage tuples if you want, also known as deconstructing

				(string firstName, string secondName) = GetName();

				WriteLine(firstName);
				WriteLine(secondName);

				// This also works

				var (theFirstName, theSecondName) = GetName();
				WriteLine(theFirstName);
				WriteLine(theSecondName);

				// and this

				(string name1, var name2) = GetName();
				WriteLine(name1);
				WriteLine(name2);
			}

			{
				// They work with the new deconstruct functionality

				// By defining a new Deconstruct method it is possile to get default values from an instance.
				var district = new DistrictData()
				{
					Name = "District 12",
					Balance = 1000
				};

				var (districtName, districtBalance) = district;

				WriteLine($"Name={districtName}");
				WriteLine($"Balance={districtBalance}");
			}

			{
				// Deconstruction methods supports overloading as well.
				var district = new DistrictData()
				{
					Name = "District 12",
					Balance = 1000,
					ID = 12
				};

				var (districtName, districtBalance, id) = district;

				WriteLine($"Name={districtName}");
				WriteLine($"Balance={districtBalance}");
				WriteLine($"ID={id}");
			}

			{
				// We can also add deconstruction methods as extension methods to existing classes
				System.Threading.Thread t1 = System.Threading.Thread.CurrentThread;
				t1.Name = "Main thread";

				var (threadName, isAlive) = t1;

				WriteLine($"Thread name={threadName}");
				WriteLine($"IsAlive={isAlive}");
			}

			{
				// When to use Tuples ?

				// MS recommend for internal and private methods
				// Use user defined classes or structs for public methods
			}
		}

		private static (string FirstName, string LastName) GetName()
		{
			return ("John", "Smith");
		}

		private static List<DistrictData> GetList()
		{
			var data = new List<DistrictData>()
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

				new DistrictData()
				{
					Balance = 300,
					ID = 3,
					Name = "District 3"
				},

				new DistrictData()
				{
					Balance = 400,
					ID = 4,
					Name = "District 4"
				},

				new DistrictData()
				{
					Balance = 500,
					ID = 5,
					Name = "District 5"
				}
			};
			return data;
		}
	}
}
