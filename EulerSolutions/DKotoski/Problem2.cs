using EulerEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutions.DKotoski
{
    class Problem2:IProblemSolution
    {
        public int ProblemID
        {
            get { return 2; }
        }

        public long Execute()
        {
            return GetFibonacci(4000000).Where(x => x % 2 == 0).Sum();
        }

        public IEnumerable<long> GetFibonacci(long max)
        {
            long previous = 1;
            yield return previous;
            long current = 2;
            yield return current;
            while (current < max)
            {
                long tmp = current;                
                current += previous;
                previous = tmp;
                yield return current;
            }
        }
    }
}
