using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
namespace UnitTestProject_Sep9_Day2.PageObjects
{

	

	class BMIPage
	{
		[FindsBy(How = How.Id, Using = "cage")]
		private IWebElement ageTextbox;


		IWebDriver driver;
		public BMIPage(IWebDriver driver)
		{

			this.driver = driver;
			//Initialize the elements of the Page 
			//PageFactory.InitElements(driver, this);
		}

		public void setAge(string age)
		{
			ageTextbox.Clear();
			ageTextbox.SendKeys(age);
		}

		public string getAge()
		{
			return ageTextbox.GetAttribute("value");
		}

	}
}
