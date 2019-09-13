using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject_Sep9.Csharp
{
	class HDFCBank : Bank
	{
		public void credit()
		{
			Console.WriteLine("HDFC Bank - Credit");
		}

		public void debit()
		{
			Console.WriteLine("HDFC Bank - Debit");
		}

		public void HDFC_ROI()
		{
			Console.WriteLine("HDFC Bank - ROT");
		}
	}
}
