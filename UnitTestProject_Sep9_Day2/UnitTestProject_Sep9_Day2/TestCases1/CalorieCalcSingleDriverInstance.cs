using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTestProject_Sep9_Day2.Selenium;

namespace UnitTestProject_Sep9_Day2.TestCases1
{
	class CalorieCalcSingleDriverInstance
	{

		IWebDriver driver;
		[OneTimeSetUp]
		public void LaunchBrowser()
		{
			driver = DriverFactory.getDriverInstance();
			DriverFactory.Driver.Url = "https://www.calculator.net/calorie-calculator.html";

		}
		[Test]
		public  void CalorieCalcTest1()
		{
			//driver = new ChromeDriver();
			//driver.Navigate().GoToUrl("https://www.calculator.net/calorie-calculator.html");
			//driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"].ToString());

			IWebElement ageTextbox = driver.FindElement(By.Id("cage"));
			ageTextbox = driver.FindElement(By.XPath(CP_ObjectRepos.agexpath));
			//perform any operation on an element -we basically first find whether 
			//the element is present
			int ElementCount = driver.FindElements(By.Id("age")).Count;
			Console.WriteLine(ElementCount);
			ageTextbox = driver.FindElement(By.Id("cage"));
			ageTextbox.SendKeys("56");

		}
		[Test]
		public void CalorieCalcTest2()
		{
			Console.WriteLine(driver.FindElements(By.LinkText("BMI")).Count);
			//driver.Navigate().Back();
			//driver.Navigate().Refresh();
			Assert.AreEqual(1, driver.FindElements(By.LinkText("BMI")).Count);
			if (driver.FindElements(By.LinkText("BMI")).Count > 0)
				driver.FindElement(By.LinkText("BMI")).Click();
		}
	[OneTimeTearDown]
	public void Close()
	{
			DriverFactory.closeBrowser();
	}

	}
}
