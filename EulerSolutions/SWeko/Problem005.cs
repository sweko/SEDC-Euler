using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerEngine;

namespace EulerSolutions.SWeko
{
    class Problem005 : IProblemSolution
    {
        public int ProblemID
        {
            get { return 5; }
        }

        public long Execute()
        {
            PrimeManager.GeneratePrimes(100);
            return Enumerable.Range(1, 20)
                    .Aggregate(new FactorCollection(), (collection, i) => collection.Combine(i.Factorize()))
                    .GetNumber();
        }
    }
}
