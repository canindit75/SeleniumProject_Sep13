using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Data.OleDb;
using System.IO;
using System.Reflection;
namespace UnitTestProject_Sep9_Day2.TestCases
{
	[TestFixture]
	class BMIExcelTest
	{
		private static string excelFileName = "BMI_Calorie_Data.xlsx";
		private static string excelSheetTabName = "BMI_Data";

		public static IEnumerable<TestCaseData> RegistrationData()
		{
			return BMIExcelTest.ReadFromExcel(excelFileName, excelSheetTabName);
		}

		[Test,TestCaseSource("RegistrationData")]
		public static void BMITestCase(string age,string sexname,string height)
		{
			Console.WriteLine(age + " " + sexname + " " + height);

		}
		public static IEnumerable<TestCaseData> ReadFromExcel(string excelFileName,string excelSheetTabName)
		{
			string exLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			exLocation = exLocation.Replace("\\bin\\Debug", "");
			string xlLocation = Path.Combine(exLocation, "TestData/" + excelFileName);			
			string connectionStr = string.Format("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = { 0 }; Extended Properties =\"Excel 12.0 Xml;HDR=YES\";", xlLocation); 
			var xlQuery = "SELECT * FROM [" + excelSheetTabName + "$]";
			if (!File.Exists(xlLocation))
				throw new FileNotFoundException();
			var testCases = new List<TestCaseData>();
			using (var connection = new OleDbConnection(connectionStr))
			{
				connection.Open();
				var command = new OleDbCommand(xlQuery, connection);
				var reader = command.ExecuteReader();
				if (reader == null)
					throw new Exception("No data returned from file");
				while (reader.Read())
				{
					var row = new List<String>();
					for(int i = 0; i < reader.FieldCount; i++)
					{
						row.Add(reader.GetValue(i).ToString());
						testCases.Add(new TestCaseData(row.ToArray()));
			
					}
				}
				if (testCases != null)
					foreach (TestCaseData testCaseData in testCases)
					{
						yield return testCaseData;
					}

			}

		}
	}
	 
}
