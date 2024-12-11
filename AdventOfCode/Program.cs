using AdventOfCode.Solutions;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode
{
    internal static class Program
    {
        public static async Task Main()
        {
            List<SolutionBundle> solutions = [.. typeof(ISolution).Assembly.GetTypes()
                .Where(x => typeof(ISolution).IsAssignableFrom(x)
                    && x.IsClass
                    && !x.IsAbstract)
                .Select(x => new SolutionBundle(
#pragma warning disable CS8604 // Possible null reference argument.
                    x.GetConstructors()[0].Invoke([]) as ISolution
#pragma warning restore CS8604 // Possible null reference argument.
                , x.CustomAttributes.Any(y=> y.AttributeType== typeof(SkippableAttribute))))
                .OrderBy(bundle => bundle.Solution.Year)
                .ThenBy(bundle => bundle.Solution.Day)
                .ThenBy(bundle => bundle.Solution.Part)];

            Stopwatch solutionStopwatch = new();

            Stopwatch runtimeStopwatch = Stopwatch.StartNew();

            foreach (SolutionBundle bundle in solutions)
            {
                object result;

                solutionStopwatch.Reset();

                if (bundle.Skippable)
                {
                    result = "SKIPPED";
                }
                else
                {
                    solutionStopwatch.Start();
                    result = await bundle.Solution.RunAsync();
                    solutionStopwatch.Stop();
                }

                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Solution for Year {bundle.Solution.Year}, Day {bundle.Solution.Day}, Part {bundle.Solution.Part} found in:");
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

        private record SolutionBundle(ISolution Solution, bool Skippable);
    }
}
