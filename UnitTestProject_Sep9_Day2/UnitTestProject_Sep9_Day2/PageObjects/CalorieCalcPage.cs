using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
namespace UnitTestProject_Sep9_Day2.PageObjects
{
	class CalorieCalcPage
	{

		[FindsBy(How = How.Id,Using = "cage")]
		[CacheLookup]
		private IWebElement ageTextbox;

		[FindsBy(How = How.Name, Using = "csex")]
		[CacheLookup]
		private IList<IWebElement> genderList;

		[FindsBy(How = How.XPath,Using = "//*[@id='cheightmeter']")]
		[CacheLookup]
		private IWebElement heightTextbox;

		[FindsBy(How = How.LinkText, Using = "BMI")]
		[CacheLookup]
		private IWebElement bmiLink;

		IWebDriver driver;
		BMIPage bp;
		public CalorieCalcPage(IWebDriver driver)
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

		public void EnterCalorieDetails(String age, String sex, String height)
		{
			ageTextbox.Clear();
			ageTextbox.SendKeys(age);

			foreach(IWebElement element in genderList)
			{
				if (element.GetAttribute("value").Equals(sex))
				{
					if(!element.Selected)
					{
						element.Click();
						break;
					}
				}
			}

			heightTextbox.Clear();
			heightTextbox.SendKeys(height);
		}

		public BMIPage BMILinkClick()
		{
			bmiLink.Click();		
			return new BMIPage(driver);
		}
		
	}
}
