using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace AdventOfCode.Solutions.Year2024
{
    internal class Day7Part1Solution : Year2024Solution
    {
        public override int Day => 7;
        public override int Part => 1;

        public override async Task<object> RunAsync()
        {
            string[] lines = await ReadAllLinesAsync();

            //DEBUG
            /*
            lines =
                [
                "190: 10 19",
                "3267: 81 40 27",
                "83: 17 5",
                "156: 15 6",
                "7290: 6 8 6 15",
                "161011: 16 10 13",
                "192: 17 8 14",
                "21037: 9 7 18 13",
                "292: 11 6 16 20",
                ];
            */

            return lines.Select(line => Test(line)).Sum();
        }

        private static long Test(string line)
        {
            string[] resultAndValues = line.Split(':', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            long result = long.Parse(resultAndValues[0].Trim());

            long[] values = resultAndValues[1]
                .Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            return PotentialValues(values).Any(x => x == result) ? result : 0;
        }

        private static IEnumerable<long> PotentialValues(long[] values)
        {
            if (values.Length == 2)
            {
                yield return values[0] + values[1];
                yield return values[0] * values[1];
            }
            else
            {
                foreach (long value in PotentialValues(values[..^1]))
                {
                    yield return value + values[^1];
                    yield return value * values[^1];
                }
            }
        }
    }
}