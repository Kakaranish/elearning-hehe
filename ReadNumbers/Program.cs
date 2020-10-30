using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ReadNumbers
{
    public class Program
    {
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

            using (StreamReader streamReader = new StreamReader(filename))
            {
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
                            numbers.Add(float.Parse(word, CultureInfo.InvariantCulture));
                        }
                    }
                }
            }

            foreach (float number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
