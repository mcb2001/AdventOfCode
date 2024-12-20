﻿namespace AdventOfCode.Solutions.Year2024
{
    internal abstract class Year2024Solution : ISolution
    {
        public int Year => 2024;

        public abstract int Day { get; }

        public abstract int Part { get; }

        public abstract Task<object> RunAsync();

        protected Task<string[]> ReadAllLinesAsync()
            => File.ReadAllLinesAsync(FullPath);

        protected Task<string> ReadAllTextAsync()
            => File.ReadAllTextAsync(FullPath);

        private string FullPath => @$"Data\{Year}{FullDay}.txt";

        private string FullDay => Day.ToString().PadLeft(2, '0');
    }
}
