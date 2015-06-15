using EulerEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutions.IIlche
{
    class Problem01:IProblemSolution
    {
        public int ProblemID
        {
            get { return 1; }
        }
        public long Execute()
        {
            return Enumerable
                .Range(1, 999)
                .Where(i => i % 3 == 0 || i % 5 == 0)
                .Sum();
        }
    }
}
