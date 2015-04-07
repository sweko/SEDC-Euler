using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerEngine;

namespace EulerSolutions.SWeko
{
    public class Problem012 : IProblemSolution
    {
        public int ProblemID
        {
            get { return 12; }
        }

        public long Execute()
        {
            PrimeManager.GeneratePrimes(100000);
            var result = GetTriangeNumbers()
                .SkipWhile(tn => tn.GetDivisors().Count() < 500)
                .First();

            return result;
        }

        private IEnumerable<int> GetTriangeNumbers()
        {
            var current = 0;
            var index = 0;
            while (true)
            {
                index ++;
                current += index;
                yield return current;
            }
        }
    }
}
