using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerEngine;

namespace EulerSolutions.SWeko
{
    class Problem001 : IProblemSolution
    {
        public int ProblemID
        {
            get { return 1; }
        }

        public long Execute()
        {
            return Enumerable
                .Range(1, 1000 - 1)
                .Where(i => i % 3 == 0 || i % 5 == 0)
                .Sum();
        }
    }
}
