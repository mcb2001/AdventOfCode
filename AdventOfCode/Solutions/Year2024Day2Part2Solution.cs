using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Solutions
{
    internal class Year2024Day2Part2Solution : Year2024Solution
    {
        public override int Day => 2;
        public override int Part => 2;

        public override async Task<object> RunAsync()
        {
            int sum = 0;

            string[] lines = await ReadLines("202402.txt");

            lines.AsParallel()
                .WithDegreeOfParallelism(1)
                .ForAll(line =>
                {

                    ++sum;
                });

            return sum;
        }

        private static bool Test(string line)
        {
            int[] digits = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            if (digits.Length < 2)
            {
                ++sum;
                return;
            }


            int previousDirection = digits[0] - digits[1];

            for (int i = 0; i < digits.Length - 1; ++i)
            {
                int direction = digits[i] - digits[i + 1];

                if (int.Sign(previousDirection) != int.Sign(direction))
                {
                    return;
                }

                int size = Math.Abs(direction);

                if (size < 1 || size > 3)
                {
                    return;
                }

                previousDirection = direction;
            }
        }
    }
}
