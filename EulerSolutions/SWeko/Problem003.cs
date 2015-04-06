using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerEngine;

namespace EulerSolutions.SWeko
{
    class Problem003: IProblemSolution
    {
        public int ProblemID
        {
            get { return 3; }
        }

        public long Execute()
        {
            PrimeManager.GeneratePrimes(10000);
            return 600851475143.Factorize().Last().Prime;
        }
    }
}
