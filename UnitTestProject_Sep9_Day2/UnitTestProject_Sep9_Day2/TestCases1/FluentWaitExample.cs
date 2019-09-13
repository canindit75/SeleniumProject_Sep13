using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject_Sep9_Day2.TestCases1
{
	[TestFixture]
	class FluentWaitExample
	{
		IWebDriver driver;
		[Test]
		public void AjaxExample()
		{

			driver = new ChromeDriver();
			driver.Navigate().GoToUrl("https://www.google.com");
			driver.Manage().Window.Maximize();
			driver.FindElement(By.Name("q")).SendKeys("s");


			WebDriverWait wait = new WebDriverWait(driver, 30);
			Func<IWebDriver,bool>waitForElement = new Func<IWebDriver,bool>((IWebDriver driver)

				}

		}	
	}
}
