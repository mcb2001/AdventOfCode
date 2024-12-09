using AdventOfCode.Solutions;
using System.Diagnostics;

namespace AdventOfCode
{
    internal static class Program
    {
        public static async Task Main()
        {
            List<ISolution> solutions =
                [
                    new Year2024Day1Part1Solution(),
                    new Year2024Day1Part2Solution(),
                    new Year2024Day2Part1Solution(),
                    new Year2024Day2Part2Solution(),
                ];

            Stopwatch solutionStopwatch = new();

            Stopwatch runtimeStopwatch = Stopwatch.StartNew();

            foreach (ISolution solution in solutions)
            {
                solutionStopwatch.Restart();
                object result = await solution.RunAsync();
                solutionStopwatch.Stop();

                Console.WriteLine("--------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Solution for Year {solution.Year}, Day {solution.Day}, Part {solution.Part} found in:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Result: {result}");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(solutionStopwatch.Elapsed);
                Console.ForegroundColor = ConsoleColor.White;
            }

            runtimeStopwatch.Stop();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Done in:");
            Console.WriteLine(runtimeStopwatch.Elapsed);
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
