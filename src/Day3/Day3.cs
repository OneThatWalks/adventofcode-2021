using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    internal class Day3
    {
        internal async Task SolveAsync()
        {
            var input = await GetInputAsync();

            var finalBinary = CalculateMostCommonBitsForInput(input);

            Console.WriteLine($"Calculated Final Average Report Gamma Rate: {finalBinary}");
            var gammaDec = Convert.ToInt32(finalBinary, 2);
            Console.WriteLine($"Calculated Final Average Report Gamma Rate In Decimal: {gammaDec}");

            var invertedBinaryString = InvertBinaryString(finalBinary);

            Console.WriteLine($"Calculated Final Epsilon Rate: {invertedBinaryString}");
            var epsilonDec = Convert.ToInt32(invertedBinaryString, 2);
            Console.WriteLine($"Calculated Final Epsilon Rate In Decimal: {epsilonDec}");

            Console.WriteLine($"Power Consumption: {gammaDec * epsilonDec}");

        }

        private string InvertBinaryString(string finalBinary)
        {
            var finalStr = "";

            for (int i = 0; i < finalBinary.Length; i++)
            {
                var character = finalBinary[i].ToString();

                if (character == "0") finalStr += "1";
                if (character == "1") finalStr += "0";
            }

            return finalStr;
        }

        private string CalculateMostCommonBitsForInput(IEnumerable<string> input)
        {
            var inputAsArray = input.ToArray();
            var bitByBitDictionary = new Dictionary<int, IList<int>>();

            for (int i = 0; i < inputAsArray.Length; i++)
            {
                var report = inputAsArray[i];

                for (int o = 0; o < report.Length; o++)
                {
                    var bit = int.Parse(report[o].ToString());

                    if (!bitByBitDictionary.ContainsKey(o)) bitByBitDictionary.Add(o, new List<int>());
                    bitByBitDictionary[o].Add(bit);
                }
            }

            var finalStr = "";

            for (int i = 0; i < bitByBitDictionary.Keys.Count(); i++)
            {
                var vals = bitByBitDictionary[bitByBitDictionary.Keys.ToArray()[i]];

                var avg = (int) Math.Round(vals.Average());

                finalStr += avg.ToString();
            }

            return finalStr;
        }

        private async Task<IEnumerable<string>> GetInputAsync()
        {
            Console.WriteLine("Retrieving input from Day3.txt");

            var input = await File.ReadAllTextAsync("Day3.txt");

            var splitStrResponse = input.Trim().Split(Environment.NewLine);

            Console.WriteLine($"Received input [{Environment.NewLine}{string.Join(Environment.NewLine, splitStrResponse)}{Environment.NewLine}]");

            return splitStrResponse;
        }
    }
}
