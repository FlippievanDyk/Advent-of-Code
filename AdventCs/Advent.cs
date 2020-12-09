using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text.RegularExpressions;

namespace AdventCs
{
	public class Program
	{
		private static int Main(string[] args)
		{
			// Console.WriteLine($"Advent day 1 pt1 {AdventDayOne.ExpenseSumThenProduct(AdventDayOne.list)}");
			// Console.WriteLine($"Advent day 1 pt2 {AdventDayOne.ExpenseSumThenProduct3(AdventDayOne.list)}");
			
			// Console.WriteLine($"Advent day 2 pt1 {AdventDay2.CheckPasswordList(AdventDay2.input.ToList())}");
			// Console.WriteLine($"Advent day 2 pt2 {AdventDay2.CheckPasswordListTobboganPlace(AdventDay2.input.ToList())}");
			
			// Console.WriteLine(
			// 	@$"Advent day 3 pt1 {AdventDay3.CheckTreesPassed(
			// 		AdventDay3.TreePattern
			// 		, new AdventDay3.Coordinate {x = 0, y = 0}
			// 		, new AdventDay3.Coordinate {x = 3, y = 1})
			// 		}");
			// Console.WriteLine(
			// 	@$"Advent day 3 pt2 {AdventDay3.CheckTreesPassedMultipleSlopes(
			// 		AdventDay3.TreePattern
			// 		, new AdventDay3.Coordinate {x = 0, y = 0}
			// 		, AdventDay3.slopes.ToList())
			// 		}");
			
			//
			// List<Dictionary<string, string>> day4Input = AdventDay4.GetPuzzleInput();
			//
			// Console.WriteLine($"Advent day 4 pt1 {AdventDay4.CheckPassportBatchNoValidation(day4Input)}");
			// Console.WriteLine($"Advent day 4 pt2 {AdventDay4.CheckPassportBatchWithValidation(day4Input)}");

			// List<string> day5Input = AdventDay5.GetPuzzleInput();
			//
			// Console.WriteLine($"Advent day 5 pt1 {AdventDay5.GetHighestBoardingPassId(day5Input)}");
			// Console.WriteLine($"Advent day 5 pt2 {AdventDay5.GetMyBoardingPass(day5Input)}");


			List<string> day6Input = AdventDay6.GetPuzzleInput();
			
			// Console.WriteLine($"Advent day 6 pt1 {AdventDay6.GetSumOfAnswersPerGroup(day6Input)}");
			Console.WriteLine($"Advent day 6 pt2 {AdventDay6.GetSumOfAnswersPerGroupAllYes(day6Input)}");

			
		return 0;
	}
	}
}