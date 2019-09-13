using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using NUnit.Framework;
namespace UnitTestProject_Sep9_Day2.TestCases1
{
	class RegTest
	{
		[Test]
		public void reg()
		{
			Regex regex = new Regex("[7-9][0-9]{9}");
			String[] str = { "1234567890", "9871234567", "9001234567", "5455454" };
			for(int i = 0; i < str.Length; i++)
			{
				Console.WriteLine(regex.IsMatch(str[i]));
			}
			
		}
	}
}
