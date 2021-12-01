using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class Day1
    {

        internal static HttpClient _httpClient = new HttpClient() { };
        internal const string _baseUrl = "https://adventofcode.com/";
        internal const string _inputUrl = "2021/day/1/input";

        internal async Task SolveAsync()
        {
            var input = await GetInputAsync();

            var numberOfDepthIncreases = GetNumberOfDepthIncreases(input);

            Console.WriteLine($"Depth increases from [{input.FirstOrDefault()}]: {numberOfDepthIncreases}");
        }

        private static int GetNumberOfDepthIncreases(IEnumerable<int> input)
        {
            var counter = 0;
            var inputAsArray = input.ToArray();
            for (var i = 0; i < input.Count(); i++)
            {
                if (i == 0) continue;
                var current = inputAsArray[i];
                var previous = inputAsArray[i - 1];
                if (current > previous)
                {
                    counter++;
                }
            }

            return counter;
        }

        private async Task<IEnumerable<int>> GetInputAsync_WhenIHaveTimeForOAuthAndSessionCookies()
        {

            Console.WriteLine($"Retrieving input from {_baseUrl}");

            var uri = new Uri(new Uri(_baseUrl), _inputUrl);

            var response = await _httpClient.GetAsync(uri);

            Console.WriteLine($"Processing response from {uri}");

            var rawStrResponse = await response.Content.ReadAsStringAsync();

            var splitStrResponse = rawStrResponse.Trim().Split(Environment.NewLine);

            Console.WriteLine($"Received input [{Environment.NewLine}{string.Join(Environment.NewLine, splitStrResponse)}{Environment.NewLine}]");

            return null;
        }

        private static async Task<IEnumerable<int>> GetInputAsync()
        {
            Console.WriteLine("Retrieving input from Day1.txt");

            var input = await File.ReadAllTextAsync("Day1.txt");

            var splitStrResponse = input.Trim().Split(Environment.NewLine);

            Console.WriteLine($"Received input [{Environment.NewLine}{string.Join(Environment.NewLine, splitStrResponse)}{Environment.NewLine}]");

            return splitStrResponse.Select(_ => int.Parse(_));
        }
    }
}
