using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;

namespace AdventCs
{
	public class Program
	{
		private static int Main(string[] args)
		{
			// Console.WriteLine($"Advent day 1 pt1 {AdventDayOne.ExpenseSumThenProduct(AdventDayOne.list)}");
			// Console.WriteLine($"Advent day 1 pt2 {AdventDayOne.ExpenseSumThenProduct3(AdventDayOne.list)}");

			
			Console.WriteLine($"Advent day 2 pt1 {AdventDay2.CheckPasswordList(AdventDay2.input.ToList())}");

			return 0;
		}
	}
}