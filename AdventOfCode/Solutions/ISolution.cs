namespace AdventOfCode.Solutions
{
    internal interface ISolution
    {
        int Year { get; }
        int Day { get; }
        int Part { get; }

        Task<object> RunAsync();
    }
}
