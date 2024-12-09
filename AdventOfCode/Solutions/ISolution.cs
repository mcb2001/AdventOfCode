using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
