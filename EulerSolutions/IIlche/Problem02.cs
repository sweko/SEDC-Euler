using EulerEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutions.IIlche
{
    class Problem02 : IProblemSolution
    {
        public int ProblemID
        {
            get { return 2; }
        }
        public long Execute()
        {
            var previous = 1;
            var next = 0;
            var current = 2;
            var sum = 2;

            while (next < 4000000 )
            {
                next = current + previous;
                if (next % 2 == 0)
                { 
                    sum += next;
                }
                previous = next - previous;
                current = next;
            }
            
            return sum;

            //1, 2, 3, 5, 8, 13    
        }
    }
}
