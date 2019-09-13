using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject_Sep9.Csharp
{
	class ICICIBank : Bank
	{
		public void credit()
		{
			Console.WriteLine("ICICI Bank - Credit");
		}

		public void debit()
		{
			Console.WriteLine("ICICI Bank - Debit");
		}

		public void ICICI_GetMinBalance()
		{
			Console.WriteLine("ICICI Bank - Get Minimum Balance");
		}

	}
}
