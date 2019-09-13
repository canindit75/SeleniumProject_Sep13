using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace UnitTestProject_Sep9_Day2.Csharp
{
	[TestFixture]
	class AMTest3 //: AMTest
	{

		[Test]
		public void TestPrivateAM()
		{
			//AMTest3 AM3 = new AMTest3();
			//Console.WriteLine(AM3.var1);
			//AM3.method1();
			AMTest AM1 = new AMTest();
			Console.WriteLine(AM1.var1);
			AM1.method1();
		}

	}
}
