using System;
using System.ComponentModel.Design;

namespace AdventCs
{
	public class Program
	{
		private static int Main(string[] args)
		{
			Console.WriteLine(AdventDayOne.ExpenseSumThenProduct(AdventDayOne.list));
			Console.WriteLine(AdventDayOne.ExpenseSumThenProduct3(AdventDayOne.list));

			return 0;
		}
	}
}