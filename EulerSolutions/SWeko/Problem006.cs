using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerEngine;

namespace EulerSolutions.SWeko
{
    class Problem006 : IProblemSolution
    {
        public int ProblemID
        {
            get { return 6; }
        }

        public long Execute()
        {
            var numbers = Enumerable.Range(1,100);
            var sum = numbers.Sum();
            var squareSum = sum*sum;
            var sumSquare = numbers.Select(n => n*n).Sum();
            return squareSum - sumSquare;
        }
    }
}
