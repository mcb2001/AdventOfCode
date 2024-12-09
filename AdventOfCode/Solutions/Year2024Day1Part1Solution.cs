using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Solutions
{
    internal class Year2024Day1Part1Solution : Year2024Solution
    {
        public override int Day => 1;
        public override int Part => 1;

        public override async Task<object> RunAsync()
        {
            string[] lines = await ReadLines("202401.txt");
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

            int sum = 0;

            for (int i = 0; i < left.Count; ++i)
            {
                sum += Math.Abs(left[i] - right[i]);
            }

            return sum;
        }
    }
}
