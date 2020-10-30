using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ReadNumbers
{
    public class Program
    {
        //List<string> toCheck = new List<string>
        //{
        //    "2"
        //    "21",
        //    "21.",
        //    "21.0",
        //    "21.1231289321",
        //    "-21.",
        //    "+21.",
        //    "+21",
        //    "-21"
        //};

        public static bool IsNumber(string str)
        {
            string pattern = @"^(0|([-+]?[1-9]{1}[0-9]*(\.[0-9]*)?))$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(str);
        }

        public static List<string> SplitWords(string line)
        {
            return line.Split(null)
                .Where(word => string.IsNullOrWhiteSpace(word) == false)
                .ToList();
        }

        public static void Main(string[] args)
        {
            string filename = "test.txt";
            List<float> numbers = new List<float>();
            StreamReader streamReader = new StreamReader(filename);
            while (true)
            {
                string line = streamReader.ReadLine();
                if (line == null)
                {
                    break;
                }

                List<string> words = SplitWords(line);
                foreach (string word in words)
                {
                    bool isNumber = IsNumber(word);
                    if (isNumber)
                    {
                        numbers.Add(float.Parse(word));
                    }
                }
            }

            streamReader.Dispose();
        }
    }
}
