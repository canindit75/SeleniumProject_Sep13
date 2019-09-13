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
	class BMIExcelTest2
	{
		private static string excelFileName = "BMI_Calorie_Data.xlsx";
		private static string excelSheetTabName = "BMI_Data";

		public static IEnumerable<TestCaseData> BMIData()
		{
			return BMIExcelTest2.ReadFromExcel(excelFileName, excelSheetTabName);
		}

		[Test,TestCaseSource("BMIData")]
		public static void BMITestCase2(string age,string sexname,string height)
		{
			Console.WriteLine(age + " " + sexname + " " + height);

		}
		public static IEnumerable<TestCaseData> ReadFromExcel(string excelFileName,string excelSheetTabName)
		{
			string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			Console.WriteLine(executableLocation);
			executableLocation = executableLocation.Replace("\\bin\\Debug", "");
			string xslLocation = Path.Combine(executableLocation, "TestData/" + excelFileName);

			string cmdText = "SELECT * FROM [" + excelSheetTabName + "$]";

			if (!File.Exists(xslLocation))
				throw new FileNotFoundException();//string.Format("File name: {0}", xslLocation), new FileNotFoundException());

			string connectionStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES\";", xslLocation);
			

			var testCases = new List<TestCaseData>();
			using (var connection = new OleDbConnection(connectionStr))
			{
				connection.Open();
				var command = new OleDbCommand(cmdText, connection);
				var reader = command.ExecuteReader();
				if (reader == null)
					throw new Exception("No data return from file");//string.Format("No data return from file, file name:{0}", xslLocation));
				while (reader.Read())
				{
					var row = new List<string>();
					var feildCnt = reader.FieldCount;
					for (var i = 0; i < feildCnt; i++)
					{
						Console.WriteLine(reader.GetValue(i).ToString());
						row.Add(reader.GetValue(i).ToString());
					}
					testCases.Add(new TestCaseData(row.ToArray()));

				}
			}

			if (testCases != null)
				foreach (TestCaseData testCaseData in testCases)
					yield return testCaseData;
		}
	}

}
