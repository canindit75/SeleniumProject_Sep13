using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTestProject_Sep9_Day2
{
	public class DriverFactory
	{
		private static IWebDriver driver;
		public static IWebDriver Driver
		{
			get
			{
				if (driver == null)
					throw new NullReferenceException();
				return driver;
			}
			private set
			{
				driver = value;
			}
		}
		public static IWebDriver getDriverInstance()
		{
			if(driver == null)
			{
				driver = new ChromeDriver();
				
			}
			return driver;
		}
		public static void navigate(string url)
		{
			Driver.Url = url;
		}
		public static void closeBrowser()
		{
			Driver.Close();
			Driver.Quit();

		}
	}
}
