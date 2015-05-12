using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerEngine;

namespace EulerSolutions.VTotocevski
{
    class Problem7 : IProblemSolution
    {
        public int ProblemID
        {
            get { return 7; }
        }

        public long Execute()
        {
            var prime = Enumerable.Range(2, 120000).Where(IsPrime).Skip(10000).Take(1).FirstOrDefault();
            return prime;
        }
        public static bool IsPrime(int number)
        {
            if (number < 2) return false;
            if (number % 2 == 0) return (number == 2);
            int root = (int)Math.Sqrt((double)number);
            for (int i = 3; i <= root; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}
