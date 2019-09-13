using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace UnitTestProject_Sep9_Day2.Extent_Reports
{
	[TestFixture]
	class CaptureScreenshot
	{
		IWebDriver driver;
		[Test]
		public void CaptureScreen()
		{
			driver = new ChromeDriver();
			driver.Navigate().GoToUrl("http://www.google.com");
			ITakesScreenshot ts = (ITakesScreenshot)driver;
			Screenshot screenshot = ts.GetScreenshot();
			screenshot.SaveAsFile("C:\\Users\\Anindita\\screenshot.png");

		}
	}
}
