using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace UnitTestProject_Sep9_Day2.Csharp
{
	[TestFixture]
	class ExceptionExample
	{
		[Test]
		public void ExceptionTest()
		{
			try
			{
				int a = 100;
				int b = 10;
				int num = a / b; // this step it fails - Divide By Zero //Terminate the Execution
				Console.WriteLine("Value of num = " + num); //Rest of the code Execution will be skipped

			}

			catch (NullReferenceException e)
			{
				Console.WriteLine("NullReference Exception");
			}
			catch(DivideByZeroException e)
			{
				Console.WriteLine(e.Message);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			try
			{
				int[] arr = new int[5];
				arr[4] = 500;
			}
			catch (IndexOutOfRangeException e)
			{
				Console.WriteLine(e.StackTrace);
			}
			finally
			{
				Console.WriteLine("Finally Block");
			}
			Console.WriteLine("Execute this step");
		}
	}
}
