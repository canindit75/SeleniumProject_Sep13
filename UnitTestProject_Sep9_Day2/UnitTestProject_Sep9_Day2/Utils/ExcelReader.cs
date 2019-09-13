    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using System.IO;
    using System.Reflection;
    using System.Data.OleDb;
    //Reference link : https://medium.com/@As_Maa/nunit-data-driven-tests-from-excel-files-8c35c8f99ace
    namespace UnitTestProject_Sep9_Day2.Utils
{
        [TestFixture]
        public class ExcelReader
        {
            private static string FILENAME = "Registeration_Data.xlsx";

            public static IEnumerable<TestCaseData> RegisrtrationData()
            {
                return ExcelReader.ReadFromExcel(FILENAME, "Registeration");
            }
            [Test,TestCaseSource("RegisrtrationData")]
           public void CheckName_Validations(string name, string email, string phone, string password)
           {
                Console.WriteLine("name = " + name + " email = " + email + " phone = " + phone + " password = " + password);
               Assert.Multiple(() =>
               {
                   Assert.IsNotEmpty(name);
                  // ......
               });      
           }
            public static IEnumerable<TestCaseData> ReadFromExcel(String excelFileName, String excelsheetTabName)
            {
                string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
				Console.WriteLine(executableLocation);
				executableLocation = executableLocation.Replace("\\bin\\Debug", "");
				string xslLocation = Path.Combine(executableLocation, "TestData/" + excelFileName);

                string cmdText = "SELECT * FROM [" + excelsheetTabName + "$]";

                if (!File.Exists(xslLocation))
                    throw new Exception(string.Format("File name: {0}", xslLocation), new FileNotFoundException());

                string connectionStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES\";", xslLocation);

                var testCases = new List<TestCaseData>();
                using (var connection = new OleDbConnection(connectionStr))
                {
                    connection.Open();
                    var command = new OleDbCommand(cmdText, connection);
                    var reader = command.ExecuteReader();
                    if (reader == null)
                        throw new Exception(string.Format("No data return from file, file name:{0}", xslLocation));
                    while (reader.Read())
                    {
                        var row = new List<string>();
                        var feildCnt = reader.FieldCount;
                        for (var i = 0; i < feildCnt; i++)
                            row.Add(reader.GetValue(i).ToString());
                        testCases.Add(new TestCaseData(row.ToArray()));
                    }
                }

                if (testCases != null)
                    foreach (TestCaseData testCaseData in testCases)
                        yield return testCaseData;
            }
        }

        }

