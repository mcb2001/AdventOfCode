using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Solutions
{
    internal class Year2024Day1Part2Solution : Year2024Solution
    {
        public override int Day => 1;
        public override int Part => 2;

        public override async Task<object> RunAsync()
        {
            string[] lines = await File.ReadAllLinesAsync(@"Data\202401.txt");
            List<int> left = [];
            List<int> right = [];

            foreach (string line in lines)
            {
                string[] split = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                left.Add(int.Parse(split[0]));
                right.Add(int.Parse(split[1]));
            }

            left.Sort();
            right.Sort();

            int score = 0;
            int prev = -1;
            int similarityScore = 0;

            foreach (int value in left)
            {
                if (prev != value)
                {
                    int firstIndex = -1;

                    do
                    {
                        ++firstIndex;
                    } while (firstIndex < right.Count && right[firstIndex] != value);

                    if (firstIndex == right.Count)
                    {
                        similarityScore = 0;
                    }
                    else
                    {
                        int lastIndex = firstIndex;

                        do
                        {
                            ++lastIndex;
                        } while (right[lastIndex] == value);

                        similarityScore = (lastIndex - firstIndex) * value;
                    }
                }

                score += similarityScore;

                prev = value;
            }

            return score;
        }
    }
}
