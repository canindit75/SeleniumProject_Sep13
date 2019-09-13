using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject_Sep9_Day2.CSharp1
{
	class Vehicle1
	{
		int speed = 100;
		public virtual void getSpeed()
		{
			Console.WriteLine("Vehicle - getSpeed()");
		}
	}
}
