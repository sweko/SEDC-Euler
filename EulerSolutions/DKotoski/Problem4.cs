using EulerEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutions.DKotoski
{
    class Problem4:IProblemSolution
    {
        public int ProblemID
        {
            get { return 4; }
        }

        public long Execute()
        {

            return (long)GetRekt().Where(x => isPalindrome(x)).Max();
        }

        public IEnumerable<int> GetRekt()
        {
            for (int i = 100; i < 1000; i++)
            {
                for (int j = 100; j < 1000; j++)
                {
                    yield return i * j;
                }
            }
        }

        public bool isPalindrome(int x)
        {
            int reversed = 0;
            int tmp = x;
            while (tmp > 0)
            {
                reversed *= 10;
                reversed += tmp % 10;
                tmp /= 10;
            }
            return reversed == x;
        }
    }
}
