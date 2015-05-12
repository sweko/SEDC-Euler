using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerEngine;

namespace EulerSolutions.VTotocevski
{
    class Problem4 : IProblemSolution
    {
        public int ProblemID
        {
            get { return 4; }
        }

        public long Execute()
        {
            long broj = 0;
            for (int i = 999; i > 100; i--)
            {
                for (int j = 999; j > 100; j--)
                {
                    long proizvod = i * j;
                    if (IsPalindrom(proizvod) == true)
                    {
                        if (proizvod > broj)
                        broj = proizvod;
                    }
                }
            }
            return broj;
        }

        private bool IsPalindrom(long number)
        {
            long straight = number;
            long reverse = 0;
            while (number > 0)
            {
                long digit = number % 10;
                reverse = reverse * 10 + digit;
                number = number / 10;
            }
            return straight == reverse;
        }
    }
}
