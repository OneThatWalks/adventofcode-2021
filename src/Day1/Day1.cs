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
        }

        private async Task<IEnumerable<int>> GetInputAsync()
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
    }
}
