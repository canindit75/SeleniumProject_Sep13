using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Excel = Microsoft.Office.Interop.Excel;

//Reference From COM -- Excel Object Library
//Reference from Assembly - Microsoft.CSharp
namespace UnitTestProject_Sep9_Day2.Selenium
{
    [TestFixture]
    public class DDTTestMethod
    {
        Excel.Application xlapp;
        Excel.Workbook xlWorkbook;
        Excel.Worksheet xlWorksheet;
        Excel.Range xlUsedRange;
		[Test]
        public void DDT()
        {
            xlapp = new Excel.Application();
            xlWorkbook = xlapp.Workbooks.Open("C:\\Users\\Anindita\\source\\repos\\UnitTestProject_Sep9_Day2\\UnitTestProject_Sep9_Day2\\TestData1\\Calorie_Data.xlsx");
            xlWorksheet = xlWorkbook.Worksheets[1];
            //UserRange is going to return the data in terms of rows/cols
            int rowcount = xlWorksheet.UsedRange.Rows.Count;
            int colcount = xlWorksheet.UsedRange.Cells.Count;
            for(int r = 1;r <= rowcount; r++)
            {
                for(int c = 1; c <= colcount; c++)
                {
                    Console.Write(xlWorksheet.Cells[r, c].Value2.ToString() + "\t");
                }
                Console.WriteLine("");
            }

            //GC.Collect();
            //GC.WaitForPendingFinalizers();

            
        } 
    }
}
