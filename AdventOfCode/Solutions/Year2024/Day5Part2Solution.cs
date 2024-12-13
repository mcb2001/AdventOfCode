using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions.Year2024
{
    internal partial class Day5Part2Solution : Year2024Solution
    {
        public override int Day => 5;
        public override int Part => 2;

        public override async Task<object> RunAsync()
        {
            string[] lines = await ReadAllLinesAsync();

            //DEBUG
            //text = "47|53\n97|13\n97|61\n97|47\n75|29\n61|13\n75|53\n29|13\n97|29\n53|29\n61|53\n97|53\n61|29\n47|13\n75|47\n97|75\n47|61\n75|61\n47|29\n75|13\n53|13\n\n75,47,61,53,29\n97,61,53,29,13\n75,29,13\n75,97,47,61,53\n61,13,29\n97,13,75,29,47";

            Regex ruleRegex = RuleRegex();
            Regex inputRegex = InputRegex();

            string[] rulelines = lines.Where(x => ruleRegex.IsMatch(x)).ToArray();
            string[] inputLines = lines.Where(x => inputRegex.IsMatch(x)).ToArray();

            List<(int Left, int Right)> rules = rulelines
                .Select(line =>
                {
                    string[] partials = line.Split('|', StringSplitOptions.RemoveEmptyEntries);
                    int left = int.Parse(partials[0]);
                    int right = int.Parse(partials[1]);
                    return (Left: left, Right: right);
                })
                .ToList();

            List<List<int>> inputs = inputLines
                .Select(line => line
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList())
                .ToList();

            int count = 0;

            foreach (List<int> input in inputs)
            {
                bool test = false;

                while (IsMatch(rules, input) is (int Left, int Right) rule)
                {
                    test = true;
                    int indexLeft = input.IndexOf(rule.Left);
                    int indexRight = input.IndexOf(rule.Right);
                    (input[indexLeft], input[indexRight]) = (input[indexRight], input[indexLeft]);
                }

                if (test)
                {
                    count += input[input.Count / 2];
                }
            }

            return count;
        }

        private static (int Left, int Right)? IsMatch(List<(int Left, int Right)> rules, List<int> input)
        {
            foreach ((int Left, int Right) rule in rules)
            {
                for (int a = 1; a < input.Count; ++a)
                {
                    if (input[a] == rule.Left)
                    {
                        for (int b = 0; b < a; ++b)
                        {
                            if (input[b] == rule.Right)
                            {
                                return rule;
                            }
                        }
                    }
                }
            }

            return null;
        }

        [GeneratedRegex("[0-9]+\\|[0-9]+")]
        private static partial Regex RuleRegex();
        [GeneratedRegex("([0-9]+,)+[0-9]+")]
        private static partial Regex InputRegex();
    }
}