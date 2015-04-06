using EulerEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutions.DKotoski
{


    public class Problem5: IProblemSolution
    {

        public int ProblemID
        {
            get {return 5; }
        }

        public long Execute()
        {
            return 1.To(20).Aggregate((a, b) => a * (b / a.Gcd(b)));
        }
    }

    public static class Extensions
    {
        public static IEnumerable<int> To(this int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                yield return i;
            }
        }
        public static IEnumerable<long> To(this long start, long end)
        {
            for (long i = start; i <= end; i++)
            {
                yield return i;
            }
        }

        public static int Gcd(this int a, int b)
        {
            if (b == 0) return a;
            else return Gcd(b, a % b);
        }
    }
}