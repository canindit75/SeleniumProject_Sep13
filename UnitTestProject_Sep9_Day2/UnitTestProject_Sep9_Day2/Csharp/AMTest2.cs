using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace UnitTestProject_Sep9_Day2.Csharp
{
	[TestFixture]
	class AMTest2
	{
		[Test]
		public void TestPrivateAM()
		{
			AMTest AM1 = new AMTest();
			Console.WriteLine(AM1.var1);
			AM1.method1();
		}

	}
}
