using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerEngine;

namespace EulerSolutions.VTotocevski
{
    class Problem1:IProblemSolution
    {
        public int ProblemID
        {
            get { return 1; }
        }

        public long Execute()
        {
            long suma = 0;
            for (int i = 3; i < 1000; i++)
            {
                if (i%3 == 0 || i%5 ==0)
                {
                    suma += i;
                }
            }
            return suma;
        }
    }
}
