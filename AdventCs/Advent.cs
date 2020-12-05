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

			//
			// Console.WriteLine($"Advent day 2 pt1 {AdventDay2.CheckPasswordList(AdventDay2.input.ToList())}");
			// Console.WriteLine($"Advent day 2 pt2 {AdventDay2.CheckPasswordListTobboganPlace(AdventDay2.input.ToList())}");


			Console.WriteLine(
				@$"Advent day 3 pt1 {AdventDay3.CheckTreesPassed(
					AdventDay3.TreePattern
					, new AdventDay3.Coordinate {x = 0, y = 0}
					, new AdventDay3.Coordinate {x = 3, y = 1})
					}");
			Console.WriteLine(
				@$"Advent day 3 pt2 {AdventDay3.CheckTreesPassedMultipleSlopes(
					AdventDay3.TreePattern
					, new AdventDay3.Coordinate {x = 0, y = 0}
					, AdventDay3.slopes.ToList())
					}");



		return 0;
	}
	}
}