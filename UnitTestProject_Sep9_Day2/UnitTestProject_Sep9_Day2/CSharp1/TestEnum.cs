using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace UnitTestProject_Sep9_Day2.CSharp1
{
	public enum Color
	{
		Red,
		Blue,
		Green
	}

[TestFixture]
class TestEnum
	{
		[Test]
		public void EnumChoice()
		{
			Color MyColor = Color.Red;
			switch(MyColor)
			{
				case Color.Red: Console.WriteLine("Red");break;
				case Color.Green: Console.WriteLine("Green"); break;
				case Color.Blue: Console.WriteLine("Blue"); break;
				default: Console.WriteLine("Invalid Color");break;
			}

		}
	}
}
