using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
namespace UnitTestProject_Sep9_Day2.Selenium
{
	[TestFixture]
	class HandlingPopups
	{
		[Test]
		public void HandlingPopupd()
		{
			ChromeDriver driver = new ChromeDriver();
			driver.Navigate().GoToUrl("https://www.calculator.net/calorie-calculator.html");
			driver.Manage().Window.Maximize();
			IJavaScriptExecutor js;
			IAlert alert;
			String alertMsg;
			try {
				js = (IJavaScriptExecutor)driver;
				//	js.ExecuteScript("alert('This is an information Message');");
				//Handle the Alert 

				alert = driver.SwitchTo().Alert();
				alertMsg = alert.Text;
				System.Threading.Thread.Sleep(3000);
				//Handle the alert - Click on OK Button
				alert.Accept();
		
				if (alertMsg.Equals("This is an information Message"))
				{
					Console.WriteLine("Alert Message Matched");
				}
				else
				{
					Console.WriteLine("Alert Message - No Match Found");
				}
			}
			catch (NoAlertPresentException e)
			{
				Console.WriteLine(e.Message);
			}
			js = (IJavaScriptExecutor)driver;
			js.ExecuteScript("confirm('Do you want to continue(Y/N)?');");
			alert = driver.SwitchTo().Alert();
			alertMsg = alert.Text;
			System.Threading.Thread.Sleep(3000);
			alert.Dismiss(); //Clicking On Cancel Button
			if (alertMsg.Equals("This is an information Message"))
			{
				Console.WriteLine("Alert Message Matched");
			}
			else
			{
				Console.WriteLine("Alert Message - No Match Found");
			}

		}

	}
}
