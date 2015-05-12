using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerEngine;

namespace EulerSolutions.VTotocevski
{
    class Problem6 : IProblemSolution
    {
        public int ProblemID
        {
            get { return 6; }
        }

        public long Execute()
        {
            long sumSquares = 0;
            long squareSums = 0;
            for (int i = 1; i <= 100; i++)
            {
                squareSums += i;
            }
            squareSums = squareSums*squareSums;
            for (int i = 1; i <= 100; i++)
            {
                sumSquares += (i*i);
            }
            return squareSums - sumSquares;
        }
    }
}
