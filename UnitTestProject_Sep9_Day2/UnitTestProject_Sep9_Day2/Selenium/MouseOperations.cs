using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI; //For SelectElement and for WebDriverWait
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;
namespace UnitTestProject_Sep9_Day2.Selenium
{
	[TestFixture]
	class MouseOperations
	{
		IWebDriver driver;
		[Test]
		public void MouseOpsTest()
		{
			driver = new ChromeDriver();
			driver.Navigate().GoToUrl("https://demo.opencart.com/");
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			//Identify Components Menu 
			IWebElement ComponentMenu = driver.FindElement(By.XPath("*[@id='menu']/div[2]/ul/li[3/a"));
			ComponentMenu.Click();
			//Declare a  WebDriverWait 
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
			wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='menu']/div[2]/ul/li[3]/div/div/ul/li[3]/a")));
			IWebElement PrinterElement = driver.FindElement(By.XPath("//*[@id='menu']/div[2]/ul/li[3]/div/div/ul/li[3]/a"));
			Actions action = new Actions(driver);
			action.MoveToElement(PrinterElement).Click().Build().Perform();
		}
	}
}
