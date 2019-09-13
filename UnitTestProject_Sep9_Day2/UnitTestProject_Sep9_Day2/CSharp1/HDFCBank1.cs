using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace UnitTestProject_Sep9_Day2.CSharp1
{
	[TestFixture]
	 class HDFCBank1 : Bank1
	{

		public const string str = "AASSS";

		public override void Debit()
		{
			Console.WriteLine("HDFCBank - Debit");
		}

		public override void Credit()
		{
			Console.WriteLine("HDFCBank - Credit");
		}

		[Test]
	  public void TestHDFCBank()
		{
			HDFCBank1 hdfc = new HDFCBank1();
			hdfc.Credit();
			hdfc.Debit();

		}

	}
}
