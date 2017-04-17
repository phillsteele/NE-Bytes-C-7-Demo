using static System.Diagnostics.Trace;

namespace NEBytesDemo
{
	public static class ExpressionBodiedMembers
	{
		public static void Run()
		{
			{
				// In C#6 expression-bodied function members were introduced.

				var m1 = new MyExpressionBodyClass1()
				{
					FirstName = "Sally",
					LastName = "Jones"
				};

				WriteLine(m1.ToString());

				WriteLine(m1.FullName);
			}

			{
				// C#7 expands the list that is allow to have expression-bodied function members

				// On constructors
				var m1 = new MyExpressionBodyClass2("Jack Jones");
				
				WriteLine(m1.Name);

				// On get / set accessors
				m1.Name = null;

				WriteLine(m1.Name);

				// On deconstructors
				{
					var m2 = new MyExpressionBodyClass2("Paddy Jones");
				}
			}
		}


	}

	public class MyExpressionBodyClass1
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		// In C#6 we could use then methods
		public override string ToString() => $"{LastName}, {FirstName}";

		// and also for readonly properties
		public string FullName => $"{FirstName} {LastName}";
	}

	public class MyExpressionBodyClass2
	{
		// Now possible on constructors
		public MyExpressionBodyClass2(string name) => _name = name;

		private string _name;

		// On get / set accessors
		public string Name
		{
			get => _name;
			set => _name = value ?? "No name specified";
		}
		
		// On finalisers
		~MyExpressionBodyClass2() => WriteLine($"Finalised {Name}");
	}

}
