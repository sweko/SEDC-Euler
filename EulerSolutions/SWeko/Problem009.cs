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
                possibleSides.SkipWhile(b => b < a).SelectMany(b =>
                    possibleSides.SkipWhile(c => c < b)
                        .Where(c => c * c == a * a + b * b)
                        .Where(c => a + b + c == 1000)
                        .Select(c => a * b * c)))
                .Single();
            return result;
        }
    }
}
