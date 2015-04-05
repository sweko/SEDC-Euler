using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerEngine;

namespace EulerSolutions.SWeko
{
    class Problem002 : IProblemSolution
    {
        public int ProblemID
        {
            get { return 2; }
        }

        public long Execute()
        {
            var result = GetFibonacciSequence().TakeWhile(f => f < 4000000).Where(f => f % 2 == 0).Sum();
            return result;
        }

        public IEnumerable<int> GetFibonacciSequence()
        {
            var previous = 1;
            var current = 2;
            yield return previous;
            yield return current;
            while (true)
            {
                current += previous;
                previous = current - previous;
                yield return current;
            }
        }


    }
}
