using EulerEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutions.DKotoski
{
    class Problem10:IProblemSolution
    {
        public int ProblemID
        {
            get { return 10; }
        }

        public long Execute()
        {
            long start = 1;
            return start.To(2000000).Where(x => Problem3.IsPrime(x)).Sum();
        }
    }
}
