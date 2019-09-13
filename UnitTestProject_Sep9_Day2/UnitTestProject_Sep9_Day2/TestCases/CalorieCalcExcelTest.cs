using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.OleDb;
using System.Reflection;
using NUnit.Framework;
namespace UnitTestProject_Sep9_Day2.TestCases
{
	[TestFixture]
	class CalorieCalcExcelTest
	{
		private static string excelFileName = "Calorie_Calc_Data.xlsx";
		private static string excelSheetTabName = "Calorie_Data";

		public static IEnumerable<TestCaseData> CalorieCalcData()
		{
			return CalorieCalcExcelTest.ReadFromExcel1(excelFileName, excelSheetTabName);
		}

		[Test, TestCaseSource("CalorieCalcData")]
		public static void TestCase(string age, string sexname, string height)
		{
			Console.WriteLine(age + " " + sexname + " " + height);
		}

		public static IEnumerable<TestCaseData> ReadFromExcel1(string exceFileName, string excelSheetName)
		{
			string exLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			exLocation = exLocation.Replace("\\bin\\Debug", "");
			string xlLocation = Path.Combine(exLocation, "TestData/" + excelFileName);
			string xlQuery = "SELECT * FROM [" + excelSheetTabName + "$]";
			string connectionStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES\";", xlLocation);
			if (!File.Exists(xlLocation))
				throw new FileNotFoundException();
			var testCases = new List<TestCaseData>();
			using (var connection = new OleDbConnection(connectionStr))
			{
				connection.Open();
				var command = new OleDbCommand(xlQuery, connection);
				var reader = command.ExecuteReader();
				if (reader == null)
					throw new Exception("No Data Returned");
				while (reader.Read())
				{
					var row = new List<String>();
					for (int i = 0; i < reader.FieldCount; i++)
					{
						row.Add(reader.GetValue(i).ToString());
					}
					testCases.Add(new TestCaseData(row.ToArray()));
				}
				if (testCases != null)
				{
					foreach (TestCaseData testCaseData in testCases)
					{
						yield return testCaseData;
					}
				}

			}

		}
	}
}

