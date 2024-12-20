﻿using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions.Year2024
{
    internal partial class Day3Part1Solution : Year2024Solution
    {
        public override int Day => 3;
        public override int Part => 1;

        public override async Task<object> RunAsync()
        {
            string text = await ReadAllTextAsync();

            //DEBUG
            //text = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

            //mul(365,15)
            Regex lookfor = MultiplierRegex();

            int sum = 0;

            foreach (Match match in lookfor.Matches(text))
            {
                int left = int.Parse(match.Groups[1].Value);
                int right = int.Parse(match.Groups[2].Value);
                int value = left * right;
                sum += value;
            }

            return sum;
        }

        [GeneratedRegex("mul\\(([0-9]{1,3}),([0-9]{1,3})\\)")]
        private static partial Regex MultiplierRegex();
    }
}
