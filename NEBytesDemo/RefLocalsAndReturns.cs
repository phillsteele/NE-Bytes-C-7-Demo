using System;
using static System.Diagnostics.Trace;

namespace NEBytesDemo
{
	public static class RefLocalsAndReturns
	{
		public static void Run()
		{
			{
				// Consider the matrix
				DisplayMatrix();
			}



			{
				// Consider the method Find1
				var coordinates = Find1(_matrix, (val) => val == 55);

				// This only returns the coordinates of the position in the matrix with the value 55

				// To change that value we now need the following.
				_matrix[coordinates.i, coordinates.j] = 56;

				WriteLine(_matrix[coordinates.i, coordinates.j]);
			}





			{
				// It would be better if we were able to reference this value directly.

				// Consider method Find2
				var valItem1 = Find2(_matrix, (val) => val == 66);

				WriteLine(valItem1);

				valItem1 = 67;

				WriteLine(_matrix[2, 1]);

				// The above doesn't work as valItem is still an int and therefore a value type,
				// it just has a copy of the data at the position that contains the value 66


				// For this to work, we need to add the ref keyword to the variable declaration
				// and to the method

				ref var valItem2 = ref Find2(_matrix, (val) => val == 66);

				WriteLine(valItem2);

				valItem2 = 67;

				WriteLine(_matrix[2, 1]);

			}





			// Rules
			{
				// You can't assign a value to a ref variable.
				// ref int i = 7;

				// This works
				int x = 7;
				ref int y = ref x;
				y = 8;
				WriteLine(x);

				// Also you cannot reference a variable whose lifetime doesn't exist
				// beyond the method in which it is defined -- see method GetValue().

				// Rules ensure can't accidentally mix value variables and reference variables.

				// Also that you can't reference memory read to be garbage collected.
			}

		}





		// Straight from MS
		public static (int i, int j) Find1(int[,] matrix, Func<int, bool> predicate)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					if (predicate(matrix[i, j]))
					{
						return (i, j);
					}
				}
			}
			return (-1, -1); // Not found
		}

		// The method needs to contain the keyword ref in its return type
		public static ref int Find2(int[,] matrix, Func<int, bool> predicate)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					if (predicate(matrix[i, j]))
					{
						// Finally we need to say that we are returning by ref
						return ref matrix[i, j];
					}
				}
			}
			throw new InvalidOperationException("Not found");
		}

		// Won't compile
		//public static ref string GetValue()
		//{
		//	string x = "hi there";

		//	return ref x;
		//}

		private static void DisplayMatrix()
		{
			for (int i = 0; i < _matrix.GetLength(0); i++)
			{
				for (int j = 0; j < _matrix.GetLength(1); j++)
				{
					WriteLine($"i={i}, j={j}, Value={_matrix[i, j]}");
				}
			}
		}

		private static int[,] _matrix = new[,] {
			{ 11, 22 },
			{ 33, 44 },
			{ 55, 66 },
			{ 77, 88 }
		};
	}
}
