using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using UnitTestProject_Sep9_Day2.PageObjects;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
namespace UnitTestProject_Sep9_Day2.TestCases
{
	[TestFixture]
	class CalorieCalcTest
	{
		BMIPage bp;
		IWebDriver driver;
		[Test]
		public void EnterCaloriePageTestCase()
		{
			//Launching the browser
			driver = new ChromeDriver();
			driver.Navigate().GoToUrl("https://www.calculator.net/calorie-calculator.html");
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

			CalorieCalcPage cp = new CalorieCalcPage(driver);
			PageFactory.InitElements(driver,cp);
			cp.EnterCalorieDetails("56", "f", "155");
			bp = cp.BMILinkClick();
			//bp = new BMIPage(driver);//cp.BMILinkClick();
			PageFactory.InitElements(driver, bp);
			//BMIPage bp = new BMIPage(driver);
			bp.setAge("67");



		}
	}
}
