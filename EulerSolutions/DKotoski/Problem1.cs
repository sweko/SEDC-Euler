using EulerEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutions.DKotoski
{
    class Problem1:IProblemSolution
    {
        public int ProblemID
        {
            get { return 1; }
        }

        public long Execute()
        {
            long start =1;
            return start.To(999).Where(x => x % 3 == 0 || x % 5 == 0).Sum();
        }
    }
}
