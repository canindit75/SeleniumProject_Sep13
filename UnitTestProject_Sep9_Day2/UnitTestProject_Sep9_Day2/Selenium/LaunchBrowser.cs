using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Configuration;
namespace UnitTestProject_Sep9_Day2.Selenium
{
	[TestFixture]
	class LaunchBrowser
	{
		IWebDriver driver;
		String browser = "chrome";
		[Test]
		public void LaunchBrowserTest()
		{

			if (browser.Equals("chrome"))
			{
				driver = new ChromeDriver();
			}
			else if(browser.Equals("firefox"))
			{
				driver = new FirefoxDriver();
			}

			//driver.Navigate().GoToUrl("https://www.calculator.net/calorie-calculator.html");
			driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"].ToString());

			IWebElement ageTextbox = driver.FindElement(By.Id("cage"));
			ageTextbox = driver.FindElement(By.XPath(CP_ObjectRepos.agexpath));
			//perform any operation on an element -we basically first find whether 
			//the element is present
			int ElementCount =driver.FindElements(By.Id("age")).Count;
			Console.WriteLine(ElementCount);
			driver.FindElement(By.LinkText("BMI")).Click();
			driver.Navigate().Back();
			driver.Navigate().Refresh();
			ageTextbox = driver.FindElement(By.Id("cage"));
			ageTextbox.SendKeys("56");
			//driver.Close();

			//ageTextbox = driver.FindElement(By.Id("cage"));
			





		}

	}
}
