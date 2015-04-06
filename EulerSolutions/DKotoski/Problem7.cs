using EulerEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutions.DKotoski
{
    class Problem7:IProblemSolution
    {
        public int ProblemID
        {
            get { return 7; }
        }

        public long Execute()
        {
            long x = 1;
            return x.To(long.MaxValue).Where(k=>Problem3.IsPrime(k)).ElementAt(10000);
        }

    }
}
