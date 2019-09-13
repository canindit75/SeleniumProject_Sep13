using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using System.Reflection;
using System.Data.OleDb;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTestProject_Sep9_Day2.PageObjects;
using SeleniumExtras.PageObjects;
using UnitTestProject_Sep9_Day2.Utils;
namespace UnitTestProject_Sep9_Day2.TestCases1
{
	[TestFixture]
	class CalorieExcelDataDrivenTest 
	{
		private static string excelFileName = "Calorie_Data.xlsx";
		private static string excelSheetName = "CalorieTestSet";
		static IWebDriver driver;
		public static IEnumerable<TestCaseData> CalorieCalcData()
		{
			return CalorieExcelDataDrivenTest.ReadFromExcel(excelFileName, excelSheetName);
		}

		public static IEnumerable<TestCaseData> ReadFromExcel(String excelFileName, String excelSheetName)
		{
			//find the location of the dll 
			string exLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

			Console.WriteLine("DLL Location : " + exLocation);
			exLocation = exLocation.Replace("\\bin\\Debug", "");
			string xlLocation = Path.Combine(exLocation, "TestData1\\" + excelFileName);
			Console.WriteLine("xl Location : " + xlLocation);
			if (!File.Exists(xlLocation))
				throw new FileNotFoundException();
			//Reference System.Data assembly
			string connectionStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES\";", xlLocation);
			string xlQuery = "SELECT * FROM [" + excelSheetName + "$]";
			using(var connection  = new OleDbConnection(connectionStr))
			{
				connection.Open();
				var command = new OleDbCommand(xlQuery, connection);
				var reader = command.ExecuteReader();
				var testCase = new List<TestCaseData>(); //testcasedata 
				//which will send back to my testcase
				
				while (reader.Read())
				{
					var row = new List<String>(); //for each row
					for (int i = 0; i < reader.FieldCount; i++)
					{
						row.Add(reader.GetValue(i).ToString());
					}
					testCase.Add(new TestCaseData(row.ToArray()));
				}
				foreach (TestCaseData testCaseData in testCase)
				{
					yield return testCaseData;
				}

			}

		}

		
		[SetUp]
		public void LaunchBrowser()
		{
			driver = new ChromeDriver();
			driver.Navigate().GoToUrl("https://www.calculator.net/calorie-calculator.html");
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			//driver = DriverFactory.getDriverInstance();
			//DriverFactory.Driver.Url = "https://www.calculator.net/calorie-calculator.html";
			//driver.Navigate().GoToUrl(DriverFactory.Driver.Url);

		}
		[Test,TestCaseSource("CalorieCalcData")]
		public static void CalorieExcelDDT(string age, String sexname,string height)
		{
			Console.WriteLine(age + " " + sexname + " " + height);
			CalorieCalcPage cp = new CalorieCalcPage(driver);
			PageFactory.InitElements(driver, cp);
		
			cp.EnterCalorieDetails(age, sexname, height);
		}

		[TearDown]
		public void Close()
		{
			if(driver!=null)
				DriverFactory.closeBrowser();
		}

	}
}
