using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerEngine;

namespace EulerSolutions.SWeko
{
    class Problem009 : IProblemSolution
    {
        public int ProblemID
        {
            get { return 9; }
        }

        public long Execute()
        {
            var possibleSides = Enumerable.Range(1, 500).ToList();
            var result = possibleSides.SelectMany(a =>
                possibleSides.SkipWhile(b => b < a)
                    .Where(b => a * a + b * b == (1000 - a - b) * (1000 - a - b))
                    .Select(b => a * b * (1000 - a - b)))
                .First();
            return result;
        }
    }
}
