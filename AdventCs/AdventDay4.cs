using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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
			rawPuzzleInput.Add("");

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
		
			var b = puzzleInput
				.Select(x => x.Replace("\r", " "));
			
			List<Dictionary<string, string>> k = b.Select(t => t.Split(" ")
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

		public static int CheckPassportBatchNoValidation(List<Dictionary<string, string>> passports)
		{
			return passports.Count(IsPassportComplete);
		}

		public static bool CheckPassportValidation(Dictionary<string, string> passport)
		{
			foreach ((string key, string value) in passport)
			{
				switch (key)
				{
					case "byr":
						if (value.Length == 4 
						    && int.Parse(value)>= 1920
						    && int.Parse(value)<= 2002
						    )
							break;
						return false;
					case "iyr":
						if (value.Length == 4
						    && int.Parse(value) >= 2010
						    && int.Parse(value) <= 2020
						    ) 
							break;
						return false; 
						
					case "eyr":
						if (value.Length == 4 
						    && int.Parse(value)>= 2020 
						    && int.Parse(value)<= 2030
						    ) 
							break;
						return false;
					case "hgt":
						Regex re = new Regex(@"(\d+)([a-zA-Z]+)");
						Match res = re.Match(value);

						string numberString = res.Groups[1].Value;
						string charString = res.Groups[2].Value;
						bool tryParse = int.TryParse(numberString, out int length);

						if(charString == "cm" 
						   && length <= 193
						   && length >= 150
						   || 
						   charString == "in" 
						   && length <= 76 
						   && length >= 59
						)
							break;
						return false;
					case "hcl":
						Regex r = new Regex("(#)([a-f0-9])");
						if (r.IsMatch(value)) 
							break;
						return false;
					case "ecl":
						if (value == "amb"
						    || value == "blu"
						    || value == "brn"
						    || value == "gry"
						    || value == "grn"
						    || value == "hzl"
						    || value == "oth"
						)
							break;
						return false;
					case "pid":
						
						bool isNum = int.TryParse(value, out int _);
						if (value.Length == 9
						    && isNum) break;
						return false; 
				}
			}
			return true;
		}
		
		
		
		public static int CheckPassportBatchWithValidation(List<Dictionary<string, string>>  passports)
		{
			IEnumerable<Dictionary<string, string>> a =  passports.Where(IsPassportComplete);
			return a.Count(CheckPassportValidation);
		}
		
		
	}
}