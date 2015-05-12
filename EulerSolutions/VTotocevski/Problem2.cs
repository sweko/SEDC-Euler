using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerEngine;

namespace EulerSolutions.VTotocevski
{
    class Problem2 : IProblemSolution
    {
        public int ProblemID
        {
            get { return 2; }
        }

        public long Execute()
        {
            long prevNum = 1;
            long fibon = 0;
            long currentNum = 2;
            long suma = 2;
            while (fibon < 4000000)
            {               
                fibon = currentNum + prevNum;
                if (fibon%2 == 0)
                {
                    suma += fibon;
                }
                prevNum = fibon - prevNum;
                currentNum = fibon;
            }
            return suma;
        }
    }
}
