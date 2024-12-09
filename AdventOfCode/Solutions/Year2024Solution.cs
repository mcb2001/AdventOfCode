using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Solutions
{
    internal abstract class Year2024Solution : ISolution
    {
        public int Year => 2024;

        public abstract int Day { get; }

        public abstract int Part { get; }

        public abstract Task<object> RunAsync();

        protected Task<string[]> ReadLines(string file)
            => File.ReadAllLinesAsync(@$"Data\{file}");
    }
}
