using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventCs
{
	public class AdventDay6
	{
		private const string PuzzlePath = "C:/Users/Flippie/Documents/GIT/Advent-of-Code/puzzleInput/day6.txt";

		public static List<string> GetPuzzleInput()
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
			
			string interim = string.Empty;
			foreach (string s in rawPuzzleInput)
			{
				if (s != "") interim += " " + s;
				else
				{
					puzzleInput.Add(interim);
					interim = string.Empty;
				}
			}
			
			return puzzleInput;
		}

		public static int GetSumOfAnswersPerGroup(List<string> groupAnswers)
		{

			var sumOfYesPerGroup = groupAnswers
				.Select(x => x
					.ToCharArray()
					.Distinct()
					.Where(char.IsLower)
					.ToArray()
					.Length)
				.Sum();
				
			
			return sumOfYesPerGroup;
		}
	}
}