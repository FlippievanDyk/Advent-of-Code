using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace AdventCs
{
	public class AdventDay5
	{

		private const string PuzzlePath = "C:/Users/Flippie/Documents/GIT/Advent-of-Code/puzzleInput/day5.txt";

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

			return rawPuzzleInput;
		}

		private static (IEnumerable<char> row, IEnumerable<char> Column) SplitBoardingPassValues(string boardingpass)
		{
			IEnumerable<char> row = boardingpass
				.Take(7);
			IEnumerable<char> column = boardingpass
				.TakeLast(3);
			return (row, column);
		}

		public static int StringBinaryRepresentationToInt(IEnumerable<char> binary)
		{
			IEnumerable<char> enumerable = binary as char[] ?? binary.ToArray();
			int i = enumerable.Count()-1;
			int t = 0;
			foreach (char c in enumerable)
			{
				t += c switch
				{
					'B' => (int)Math.Pow(2,i),
					'F' => 0,
					'R' => (int)Math.Pow(2,i),
					'L' => 0,
					_ => throw new ArgumentOutOfRangeException()
				};
								i--;

			}
			return t;
		}
		
		public static int TranslateRowColumnToId(int row, int column)
		{
			return row * 8 + column;
		}

		public static int GetBoardingPassId(string boardingPass)
		{

			
			(IEnumerable<char> row, IEnumerable<char> column) = SplitBoardingPassValues(boardingPass);

			// Console.WriteLine($"{row.Count()},{column.Count()},{boardingPass.Length}");

			int rowNumber = StringBinaryRepresentationToInt(row);
			int columnNumber = StringBinaryRepresentationToInt(column);

			// Console.WriteLine($"{boardingPass},{rowNumber},{columnNumber},{rowNumber * 8 + columnNumber}");
			
			return TranslateRowColumnToId(rowNumber, columnNumber);

		}

		public static int GetHighestBoardingPassId(List<string> BoardingPass)
		{
			return BoardingPass.Max(x =>
				GetBoardingPassId(x)

			);

		}

		public static int GetMyBoardingPass(List<string> boardingPass)
		{
			List<int> orderedBoardingPass = boardingPass
				.Select(GetBoardingPassId)
				.OrderBy(x => x)
				.ToList();

			int prev = orderedBoardingPass.First();
			
			foreach (int next in orderedBoardingPass)
			{
				if (next - prev == 2) return next - 1;
				prev = next;
			}
			
			
			return 0;
		}

		
		
		
		
	}
}