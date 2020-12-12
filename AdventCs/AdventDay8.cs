using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCs
{
	public class AdventDay8
	{
		// public const string PuzzlePath = "C:/Users/Flippie/Documents/GIT/Advent-of-Code/puzzleInput/day8.txt";
		public const string PuzzlePath = "F:/Flippie/Documents/GIT/Advent-of-Code/puzzleInput/day8.txt";
		// public const string PuzzlePath = "F:/Flippie/Documents/GIT/Advent-of-Code/puzzleInput/day8example.txt";


		public enum InstructionType
		{
			NoOperation,
			Accumulator,
			Jump
		}

		public record Instruction
		{
			public InstructionType instructionType { get; set; }
			public int instructionValue { get; init; }
			public int instructionIndex { get; init; }
			public bool usedAlready { get; set; }
		}


		private static InstructionType StringToInstruction(string type)
		{
			return type switch
			{
				string g when g.Contains("nop") => InstructionType.NoOperation,
				string g when g.Contains("acc") => InstructionType.Accumulator,
				string g when g.Contains("jmp") => InstructionType.Jump,
				_ => throw new Exception("wtf?")
			};
		}



		private static List<Instruction> ParseInstructions(List<string> input)
		{
			return input.Select((x, i) =>
				{
					var a = x.Split(" ");
					var b = StringToInstruction(a[0]);
					var c = int.Parse(a[1]);
					return new Instruction {instructionType = b, instructionValue = c, instructionIndex = i, usedAlready = false};
				})
					.ToList()
				;
		}

		public static (int next, int accumulator) handleInstruction(Instruction instruction, int accumulator)
		{
			return instruction.instructionType switch
			{
				InstructionType.NoOperation => (instruction.instructionIndex +1 , accumulator),
				InstructionType.Accumulator => (instruction.instructionIndex +1 , accumulator + instruction.instructionValue),
				InstructionType.Jump => (instruction.instructionIndex + instruction.instructionValue , accumulator),
			};
		}

		public static int AccumulatorBeforeInfiniteLoop(List<string> input)
		{
			var instructions = ParseInstructions(input).ToArray();

			int accumulator = 0;
			int instructionIndex = 0;

			Instruction instruction = instructions[instructionIndex];

			while (instruction.usedAlready == false)
			{
				instructions[instructionIndex].usedAlready = true;
				(instructionIndex, accumulator) = handleInstruction(instruction, accumulator);
				instruction = instructions[instructionIndex];
			}
			
	        return accumulator;
        }

		public static bool SubstituteInstructionAtIndex(Instruction[] instructions, int index)
		{
			if (instructions[index].instructionType == InstructionType.Accumulator)
				return false;
			instructions[index].instructionType = instructions[index].instructionType == InstructionType.Jump ? InstructionType.NoOperation : InstructionType.Jump;
			return true;
		}
		

		public static int AccumulatorAfterProgramFinishes(List<string> input)
		{
			Instruction[] instructions = ParseInstructions(input).ToArray();
			
			int maxIndex = instructions.Length - 1;
			int accumulator = 0;

			for (var index = 0; index < instructions.Length; index++)
			{
				var instruction1 = instructions[index];
				SubstituteInstructionAtIndex(instructions, index);
				accumulator = 0;
				var instructionIndex = 0;

				Instruction instruction = instructions[instructionIndex];

				while (instruction.usedAlready == false)
				{
					instructions[instructionIndex].usedAlready = true;
					(instructionIndex, accumulator) = handleInstruction(instruction, accumulator);
					if (instructionIndex > maxIndex)
					{
						return accumulator;
					}

					instruction = instructions[instructionIndex];
				}

				SubstituteInstructionAtIndex(instructions, index);
				index++;

				foreach (var instruction2 in instructions)
				{
					instruction2.usedAlready = false;
				}
			}

			//end new loop
			return accumulator;
		}

    }
}