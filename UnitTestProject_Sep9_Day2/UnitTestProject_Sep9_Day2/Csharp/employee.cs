using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace UnitTestProject_Sep9_Day2.Csharp
{
	[TestFixture]
	class employee
	{
		int empid;
		string empname;
		static string company;
		static int empcount=0;
		public employee()
		{
			empcount=empcount+1;
			
		}
		public void insertemployee(int id, string name,string comp)
		{
			empid = id;
			empname = name;
			company = comp;
		}

		public void displayempInfo()
		{
			Console.WriteLine("empcount = " + empcount + " empid = " + this.empid + " empname = " + this.empname + " company = " + company);
		}

		public static void changComp(string comp)
		{
			company = comp;
		}
		[Test]
		public void employeeTest()
		{
			employee e1 = new employee();
			//e1.insertemployee(100, "Rakesh", "Capgemini");
			employee.changComp("Capgemini");
			e1.displayempInfo();
			Console.WriteLine(employee.empcount);
			employee e2 = new employee();
			//e2.insertemployee(200, "Rajesh", "Deloitte");
			employee.changComp("Deloitte");
			e2.displayempInfo();
			e1.displayempInfo();
			Console.WriteLine(employee.company);
			Console.WriteLine(employee.empcount);
			employee e3 = new employee();
			//e3.insertemployee(300, "Ravi", "Reliance");
			//e1.displayempInfo();
			//e2.displayempInfo();
			//e3.displayempInfo();
			Console.WriteLine(employee.company);
			Console.WriteLine(employee.empcount);



		}
	}
}
