using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;

namespace AdventCs
{
	public static class AdventDay4
	{
		private const string PuzzlePath = "C:/Users/Flippie/Documents/GIT/Advent-of-Code/puzzleInput/day4.txt";

		// private const string PuzzlePath = "C:/Users/Flippie/Documents/GIT/Advent-of-Code/puzzleInput/day4Demo.txt";
		public static List<Dictionary<string, string>>  GetPuzzleInput()
		{
			List<string> rawPuzzleInput = new List<string>();

			if (!File.Exists(PuzzlePath)) throw new FileNotFoundException("Supply Puzzle input!");

			string line;
			StreamReader file = new(PuzzlePath);

			while ((line = file.ReadLine()) != null)
			{
				rawPuzzleInput.Add(line);
			}

			List<string> puzzleInput = new List<string>();
			string interim = String.Empty;
			foreach (string s in rawPuzzleInput)
			{
				if (s != "") interim += " " + s;
				else
				{
					puzzleInput.Add(interim);
					interim = string.Empty;
				}
			}

			var a = puzzleInput.First().Split(" ");

			List<Dictionary<string, string>> k = puzzleInput.Select(t => t.Split(" ")
					.Select(splitOn => splitOn.Split(':'))
					.Where(x => x.Length > 1)
					.ToDictionary(ad => ad[0], ad => ad[1]))
				.ToList();
			

			return k;
		}

		public static List<string> requiredFields = new()
		{
			"byr",
			"iyr",
			"eyr",
			"hgt",
			"hcl",
			"ecl",
			"pid",
			"cid",
		};

		private static bool IsPassportComplete(Dictionary<string, string>  passport)
		{
			return requiredFields.Where(x => x != "cid").All(passport.ContainsKey);
		}

		public static int CheckPassportBatchNoValidation(List<Dictionary<string, string>>  passports)
		{
			return passports.Count(IsPassportComplete) + 1;
		}
		
		
	}
}