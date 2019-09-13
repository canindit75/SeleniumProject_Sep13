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
    public class TestBaseClass
    {
        public IWebDriver driver;
        [SetUp]
        public void LaunchBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }
        [TearDown]
        public void CloseBrowser()
        {
            if (driver != null)
            {
                driver.Close();
                driver.Quit();
            }
        }
    }
}
