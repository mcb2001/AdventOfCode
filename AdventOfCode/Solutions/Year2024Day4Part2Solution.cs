using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Solutions
{
    internal partial class Year2024Day4Part2Solution : Year2024Solution
    {
        public override int Day => 4;
        public override int Part => 2;

        private readonly static char[][] msms =
            [
                ['M','.','S'],
                ['.','A','.'],
                ['M','.','S'],
            ];

        private readonly static char[][] mmss =
            [
                ['M','.','M'],
                ['.','A','.'],
                ['S','.','S'],
            ];

        private readonly static char[][] smsm =
            [
                ['S','.','M'],
                ['.','A','.'],
                ['S','.','M'],
            ];

        private readonly static char[][] ssmm =
            [
                ['S','.','S'],
                ['.','A','.'],
                ['M','.','M'],
            ];

        public override async Task<object> RunAsync()
        {
            string[] lines = await ReadAllLinesAsync();

            //DEBUG
            /*
            lines =
                [
                    ".M.S......",
                    "..A..MSMS.",
                    ".M.S.MAA..",
                    "..A.ASMSM.",
                    ".M.S.M....",
                    "..........",
                    "S.S.S.S.S.",
                    ".A.A.A.A..",
                    "M.M.M.M.M.",
                    "..........",
                ];
            */

            char[][] matrix = lines.Select(line => line.ToCharArray()).ToArray();

            int count = 0;

            for (int y = 0; y < matrix.Length - 2; ++y)
            {
                for (int x = 0; x < matrix[y].Length - 2; ++x)
                {
                    char[][] partial =
                        [
                        [..matrix[y][x..(x+3)]],
                        [..matrix[y+1][x..(x+3)]],
                        [..matrix[y+2][x..(x+3)]],
                        ];

                    if (Match(partial, msms))
                    {
                        ++count;
                    }
                    else if (Match(partial, mmss))
                    {
                        ++count;
                    }
                    else if (Match(partial, smsm))
                    {
                        ++count;
                    }
                    else if (Match(partial, ssmm))
                    {
                        ++count;
                    }
                }
            }

            return count;
        }

        private static bool Match(char[][] partial, char[][] match)
        {
            for (int y = 0; y < partial.Length; ++y)
            {
                for (int x = 0; x < partial[y].Length; ++x)
                {
                    if (match[y][x] == '.')
                    {
                        continue;
                    }
                    else if (match[y][x] != partial[y][x])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}