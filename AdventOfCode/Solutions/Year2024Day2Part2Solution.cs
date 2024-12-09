namespace AdventOfCode.Solutions
{
    internal class Year2024Day2Part2Solution : Year2024Solution
    {
        public override int Day => 2;
        public override int Part => 2;

        public override async Task<object> RunAsync()
        {
            int sum = 0;

            string[] lines = await ReadAllLinesAsync();

            //Debug
            /*
            lines =
                [
                    "7 6 4 2 1",
                    "1 2 7 8 9",
                    "9 7 6 2 1",
                    "1 3 2 4 5",
                    "8 6 4 4 1",
                    "1 3 6 7 9",
                ];
            */

            foreach (string line in lines)
            {
                int[] digits = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (TestPartial(digits))
                {
                    ++sum;
                }
            };

            return sum;
        }

        private static bool TestPartial(int[] digits)
        {
            if (Test(digits))
            {
                return true;
            }

            for (int i = 0; i < digits.Length; i++)
            {
                int[] newDigits = [.. digits[0..i], .. digits[(i + 1)..]];

                if (Test(newDigits))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool Test(int[] digits)
        {
            if (digits.Length < 2)
            {
                return true;
            }

            bool sign = (digits[0] - digits[1]) < 0;

            for (int i = 0; i < digits.Length - 1; ++i)
            {
                int direction = digits[i] - digits[i + 1];

                if (sign != direction < 0)
                {
                    return false;
                }

                int size = Math.Abs(direction);

                if (size < 1 || size > 3)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
