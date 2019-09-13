using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
namespace UnitTestProject_Sep9_Day2.Utils
{
	[TestFixture]
	class ExcelDataReader
	{
		private static string excelFileName = "Registeration_Data.xlsx";
		private static string excelsheetTabName = "Registeration";
		[Test]
		public static void FindLocation()
		{
			string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			Console.WriteLine(executableLocation);
			executableLocation=executableLocation.Replace("\\bin\\Debug", "");
			Console.WriteLine(executableLocation);
			string xslLocation = Path.Combine(executableLocation, "TestData/" + excelFileName);
			Console.WriteLine(xslLocation);
			string cmdText = "SELECT * FROM [" + excelsheetTabName + "$]";
			Console.WriteLine(cmdText);
			if (!File.Exists(xslLocation))
				throw new Exception(string.Format("File name: {0}", xslLocation), new FileNotFoundException());

		}
	}
}
