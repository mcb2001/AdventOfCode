using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Solutions
{
    internal partial class Year2024Day4Part1Solution : Year2024Solution
    {
        public override int Day => 4;
        public override int Part => 1;

        private static readonly char[] forward = ['X', 'M', 'A', 'S'];
        private static readonly char[] backward = forward.Reverse().ToArray();

        public override async Task<object> RunAsync()
        {
            string[] lines = await ReadAllLinesAsync();

            //DEBUG
            /*
            lines =
                [
                    "MMMSXXMASM",
                    "MSAMXMSMSA",
                    "AMXSXMAAMM",
                    "MSAMASMSMX",
                    "XMASAMXAMM",
                    "XXAMMXXAMA",
                    "SMSMSASXSS",
                    "SAXAMASAAA",
                    "MAMMMXMMMM",
                    "MXMXAXMASX",
                ];
            */

            char[][] matrix = lines.Select(line => line.ToCharArray()).ToArray();

            int count = 0;

            //check left/right
            for (int y = 0; y < matrix.Length; ++y)
            {
                for (int x = 0; x < matrix[y].Length - 3; ++x)
                {
                    char[] partial = matrix[y][x..(x + 4)];

                    if (partial.SequenceEqual(forward))
                    {
                        ++count;
                    }
                    else if (partial.SequenceEqual(backward))
                    {
                        ++count;
                    }
                }
            }

            //check up/down
            for (int y = 0; y < matrix.Length - 3; ++y)
            {
                for (int x = 0; x < matrix[y].Length; ++x)
                {
                    char[] partial = [matrix[y][x], matrix[y + 1][x], matrix[y + 2][x], matrix[y + 3][x]];

                    if (partial.SequenceEqual(forward))
                    {
                        ++count;
                    }
                    else if (partial.SequenceEqual(backward))
                    {
                        ++count;
                    }
                }
            }

            //check down-right
            for (int y = 0; y < matrix.Length - 3; ++y)
            {
                for (int x = 0; x < matrix[y].Length - 3; ++x)
                {
                    char[] partial = [matrix[y][x], matrix[y + 1][x + 1], matrix[y + 2][x + 2], matrix[y + 3][x + 3]];

                    if (partial.SequenceEqual(forward))
                    {
                        ++count;
                    }
                    else if (partial.SequenceEqual(backward))
                    {
                        ++count;
                    }
                }
            }

            //check down-left
            for (int y = 0; y < matrix.Length - 3; ++y)
            {
                for (int x = 0; x < matrix[y].Length - 3; ++x)
                {
                    char[] partial = [matrix[y + 3][x], matrix[y + 2][x + 1], matrix[y + 1][x + 2], matrix[y][x + 3]];

                    if (partial.SequenceEqual(forward))
                    {
                        ++count;
                    }
                    else if (partial.SequenceEqual(backward))
                    {
                        ++count;
                    }
                }
            }

            return count;
        }
    }
}
