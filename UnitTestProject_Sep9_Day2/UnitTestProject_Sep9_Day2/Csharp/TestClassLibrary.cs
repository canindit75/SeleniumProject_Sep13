using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CalculateClassLibrary;
namespace UnitTestProject_Sep9_Day2.Csharp
{
	[TestFixture]
	class TestClassLibrary
	{
		[Test]
		public void TestAdd()
		{
			Calculator c = new Calculator();
			c.Add(10, 20);
			Console.WriteLine(c.Output());
			Assert.AreEqual(30, c.Output(),"Expected and Actual Result do not match");
		}
		[Test]
		public void TestSub()
		{
			Calculator c = new Calculator();
			c.substract(20, 10);
			Console.WriteLine(c.Output());
			Assert.AreEqual(10, c.Output(), "Expected and Actual Result do not match");
		}
	}
}
