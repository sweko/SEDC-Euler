using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerEngine;

namespace EulerSolutions.SWeko
{
    class Problem010 : IProblemSolution
    {
        public int ProblemID
        {
            get { return 10; }
        }

        public long Execute()
        {
            PrimeManager.GeneratePrimes(2000000);
            return PrimeManager.Primes.Sum();
        }
    }
}
