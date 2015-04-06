using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerEngine;

namespace EulerSolutions.SWeko
{
    class Problem007 : IProblemSolution
    {
        public int ProblemID
        {
            get { return 7; }
        }

        public long Execute()
        {
            PrimeManager.GeneratePrimes(1000000);
            return PrimeManager.Primes[10000];
        }
    }
}
