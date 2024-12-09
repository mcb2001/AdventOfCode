using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Solutions
{
    internal class Year2024Day2Part1Solution : Year2024Solution
    {
        public override int Day => 2;
        public override int Part => 1;

        public override async Task<object> RunAsync()
        {
            int sum = 0;

            string[] lines = await ReadAllLinesAsync();

            lines.AsParallel()
                .WithDegreeOfParallelism(1)
                .ForAll(line =>
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

                    ++sum;
                });

            return sum;
        }
    }
}
