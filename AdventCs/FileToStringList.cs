using System.Collections.Generic;
using System.IO;

namespace AdventCs
{
    public class FileToStringList
    {

        public static List<string> GetPuzzleInput(string path)
        {
            List<string> rawPuzzleInput = new List<string>();

            if (!File.Exists(path)) throw new FileNotFoundException("Supply Puzzle input!");

            string line;
            StreamReader file = new(path);

            while ((line = file.ReadLine()) != null)
            {
                rawPuzzleInput.Add(line);
            }
            return rawPuzzleInput;
        }
    }
}