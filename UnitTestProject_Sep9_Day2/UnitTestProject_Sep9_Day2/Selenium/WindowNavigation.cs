using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace UnitTestProject_Sep9_Day2.Selenium
{
	[TestFixture]
	class WindowNavigation
	{
		IWebDriver driver;
		[Test]
		public void WindowNavTest()
		{
			driver = new ChromeDriver();
			driver.Navigate().GoToUrl("https://www.online.citibank.co.in/products-services/online-services/internet-banking.htm");
			driver.Manage().Window.Maximize();

			//Current Window Handle - windowId
			String ParentWindowID = driver.CurrentWindowHandle;
			Console.WriteLine("Parent Window ID : " + ParentWindowID);
			
			IWebElement LoginBtn = driver.FindElement(By.XPath("//*[@title='LOGIN NOW']"));
			//Clicking on Login Button 
			LoginBtn.Click();
			//Getting the list of Current Window Handles
			IList<string> winids = driver.WindowHandles;
			Console.WriteLine("Current Number of Open Windows : " + winids.Count);
			string mainWindowID = winids[0];
			string subWindowID = winids[1];
			Console.WriteLine("Main Window ID : " + mainWindowID);
			Console.WriteLine("Sub Window ID : " + subWindowID);
			driver.SwitchTo().Window(subWindowID);
			System.Threading.Thread.Sleep(3000);

			IWebElement UserId = driver.FindElement(By.Name("User_Id"));
			UserId.SendKeys("Selenium");
			System.Threading.Thread.Sleep(2000);
			driver.Close(); //Subwindow will close
							//if our application web pages include frames 
			//driver.SwitchTo().DefaultContent();
			//driver.SwitchTo().Window(mainWindowID);
			driver.FindElement(By.Id("topMnuinsurance")).Click();
			System.Threading.Thread.Sleep(3000);
			//driver.Close();











		}
	}
}
