using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace UnitTestProject_Sep9.Csharp
{
	[TestFixture]
	class TestBankInterface
	{
		[Test]
		public void TestBank()
		{
			HDFCBank hdfc = new HDFCBank();
			hdfc.credit();
			hdfc.debit();
			hdfc.HDFC_ROI();

			ICICIBank icici = new ICICIBank();
			icici.credit();
			icici.debit();
			icici.ICICI_GetMinBalance();

			Bank b = new HDFCBank();
			b.credit();
			b.debit();

			b = new ICICIBank();
			b.credit();
			b.debit();
			
		}


	}
}
