using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Configuration;

namespace UnitTestProject_Sep9_Day2.Selenium
{
	[TestFixture]
	class ReadFromConfig
	{
		[Test]
		public void ReadConfig()
		{
			//Connection Strings
			String dbconnection = ConfigurationManager.ConnectionStrings["dbconnection"].ToString();
			Console.WriteLine("dbconnection = " + dbconnection);

			String URL = ConfigurationManager.AppSettings["URL"].ToString();
			Console.WriteLine("APP URL = " + URL);


		}
	}
}
