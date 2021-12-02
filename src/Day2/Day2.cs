using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    internal class Day2
    {

        internal async Task SolveAsync()
        {
            var input = await GetInputAsync();

            var resultTuple = CalculateFinalHorizontalAndDepthPosition(input);

            Console.WriteLine($"Final Horizontal Position: {resultTuple.horizontal}");
            Console.WriteLine($"Final Depth: {resultTuple.depth}");
            Console.WriteLine($"Final Depth of Aim: {resultTuple.aim}");
            Console.WriteLine($"Final Distance: {resultTuple.depth * resultTuple.horizontal}");

        }

        private (int horizontal, int depth, int aim) CalculateFinalHorizontalAndDepthPosition(IEnumerable<(string direction, int delta)> input)
        {
            var inputAsArray = input.ToArray();
            var horizontal = 0;
            var depth = 0;
            var aim = 0;

            for (int i = 0; i < inputAsArray.Length; i++)
            {
                var direction = inputAsArray[i].direction;
                var delta = inputAsArray[i].delta;

                switch (direction)
                {
                    case "forward":
                        horizontal += delta;
                        depth += aim * delta;
                        break;
                    case "down":
                        aim += delta;
                        break;
                    case "up":
                        aim -= delta;
                        break;
                    default:
                        break;
                }
            }

            return (horizontal, depth, aim);
        }

        private static async Task<IEnumerable<(string direction, int delta)>> GetInputAsync()
        {
            Console.WriteLine("Retrieving input from Day2.txt");

            var input = await File.ReadAllTextAsync("Day2.txt");

            var splitStrResponse = input.Trim().Split(Environment.NewLine);

            Console.WriteLine($"Received input [{Environment.NewLine}{string.Join(Environment.NewLine, splitStrResponse)}{Environment.NewLine}]");

            return splitStrResponse.Select(_ =>
            {
                var directionDeltaStrings = _.Split(' ');

                return (directionDeltaStrings[0], int.Parse(directionDeltaStrings[1]));
            });
        }
    }
}
