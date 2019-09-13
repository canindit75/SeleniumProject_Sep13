using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace UnitTestProject_Sep9_Day2.CSharp1
{
	[TestFixture]
	class Car1 : Vehicle1
	{
		int speed;
		public override void getSpeed()
		{
			Console.WriteLine("Car - getSpeed()");
		}

		[Test]
		public void CarTest()
		{
			Vehicle1 v1 = new Vehicle1();
			v1.getSpeed();
			Car1 c1 = new Car1();
			c1.getSpeed();
		}
	}
}
