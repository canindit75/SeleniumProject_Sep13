using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace UnitTestProject_Sep9_Day2.Csharp
{
	[TestFixture]
	class ThrowExample
	{

		public static void validateAge(int age)
		{
			if (age < 18)
				throw new AgeException("Invalid Age - Age should be below 18");
		}
		[Test]
		public void ThrowTest()
		{
			try
			{
				int age = 16;
				validateAge(age);

			}catch(AgeException e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}
