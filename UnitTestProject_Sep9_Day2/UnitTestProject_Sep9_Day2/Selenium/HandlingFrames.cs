using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions; //for Mouse Operations

namespace UnitTestProject_Sep9_Day2.Selenium
{
	[TestFixture]
	class HandlingFrames
	{
		IWebDriver driver;
		[Test]
		public void FramesTest()
		{
			driver = new ChromeDriver();
			driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
			driver.Manage().Window.Maximize();

			//identify the frame Element
			IWebElement frameElement = driver.FindElement(By.ClassName("demo-frame"));
	
			//Switch to the Frame Element
			driver.SwitchTo().Frame(frameElement);
			//identify drag and drop elements in the frames
			IWebElement dragElement = driver.FindElement(By.Id("draggable"));
			IWebElement dropElement = driver.FindElement(By.Id("droppable"));

			Actions action = new Actions(driver);
			action.DragAndDrop(dragElement, dropElement).Build().Perform();
			if (dropElement.Text.Equals("Dropped!"))
				Console.WriteLine("Drag and Drop Operation is Successfull");
			else
				Console.WriteLine("Could not perform Drag and Drop Operation");






		}

	}
}
