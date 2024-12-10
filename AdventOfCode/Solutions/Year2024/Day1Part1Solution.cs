namespace AdventOfCode.Solutions.Year2024
{
    internal class Day1Part1Solution : Year2024Solution
    {
        public override int Day => 1;
        public override int Part => 1;

        public override async Task<object> RunAsync()
        {
            string[] lines = await ReadAllLinesAsync();
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
