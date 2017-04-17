using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEBytesDemo
{
	public class DistrictData
	{
		public int ID { get; set; }
		
		public string Name { get; set; }

		public decimal Balance { get; set; }

		public void Deconstruct(out string name, out decimal balance)
		{
			name = "Deconstructed " + Name;
			balance = Balance;
		}


		public void Deconstruct(out string name, out decimal balance, out int id)
		{
			name = "Deconstructed " + Name;
			balance = Balance;
			id = ID;
		}
	}
}
