using EulerEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutions.DKotoski
{
    class Problem3:IProblemSolution
    {
        public int ProblemID
        {
            get { return 3; }
        }

        public long Execute()
        {
            var end = 600851475143 ;

            return (long)Enumerable.Range(2, (int)Math.Sqrt(end)).Where(x => IsPrime(x)).Where(x => end % x == 0).Max();
        }

        public static bool IsPrime(long n)
        {
            if (n <= 3)
            {
                return n > 1;
            }
            else if (n % 2 == 0 || n % 3 == 0)
            {
                return false;
            }
            for (long i = 5; i * i <= n; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
