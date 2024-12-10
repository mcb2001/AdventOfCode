using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions.Year2024
{
    internal partial class Day3Part2Solution : Year2024Solution
    {
        public override int Day => 3;
        public override int Part => 2;

        public override async Task<object> RunAsync()
        {
            string text = await ReadAllTextAsync();

            //DEBUG
            //text = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

            //mul(365,15)
            Regex lookfor = MultiplierRegex();

            int sum = 0;

            bool enabled = true;

            foreach (Match match in lookfor.Matches(text))
            {
                if (match.Value == "do()")
                {
                    enabled = true;
                }
                else if (match.Value == "don't()")
                {
                    enabled = false;
                }
                else if (enabled)
                {
                    int left = int.Parse(match.Groups[2].Value);
                    int right = int.Parse(match.Groups[3].Value);
                    int value = left * right;
                    sum += value;
                }
            }

            return sum;
        }

        [GeneratedRegex("(mul\\(([0-9]{1,3}),([0-9]{1,3})\\))|(do\\(\\))|(don't\\(\\))")]
        private static partial Regex MultiplierRegex();
    }
}
