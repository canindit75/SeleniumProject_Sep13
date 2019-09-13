using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnitTestProject_Sep9_Day2.Csharp
{
	[TestFixture]
	class TestRefAndOut
	{
		public void addNumbers(ref int i)
		{
			i = i + 1;
		}
		[Test]
		public void RefTest()
		{
			int i = 1;
			Console.WriteLine("value of i = " + i);
			addNumbers(ref i);
			Console.WriteLine("value of i = " + i);
			addNumbers(ref i);
			Console.WriteLine("value of i = " + i);
		}

		public void addNumbersOut(out int i)
		{
			i = 2;
		}
		[Test]
		public void OutTest()
		{
			int i = 1;
			Console.WriteLine("value of i = " + i);
			addNumbersOut(out i);
			Console.WriteLine("value of i = " + i);
			addNumbersOut(out i);
			Console.WriteLine("value of i = " + i);
		}

		public int AddNumbers(int n1, int n2)
		{
			int sum = n1 + n2;
			return sum;
		}
		[Test]
		public void NamedParamsOptional()
		{
			Console.WriteLine(AddNumbers(10, 20));
			Console.WriteLine(AddNumbers(n2: 30, n1: 40));
			//Positional arguments cannot follow named arguments. It throws compilation error.
			//Console.WriteLine(AddNumbers(n2: 30, 40));
			//Name Arguments can follow Positional Arguments
			Console.WriteLine(AddNumbers(12, n2: 50));

		}
		public const string n = "Test";
		public const int n1 = 100;
		public readonly int var1;
		[Test]
		public void constreadonly()
		{
			Console.WriteLine("value of n :" + n);
			Console.WriteLine("value of n1 :" + n1);
			Console.WriteLine(var1);
		}

		

		public TestRefAndOut()
		{
			var1 = 111;
			Console.WriteLine(var1);
		}
		}

	}
