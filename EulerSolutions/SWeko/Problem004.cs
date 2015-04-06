using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerEngine;

namespace EulerSolutions.SWeko
{
    class Problem004 : IProblemSolution
    {
        public int ProblemID
        {
            get { return 4; }
        }

        public long Execute()
        {
            var numbers = Enumerable.Range(100, 900);

            return numbers
                .SelectMany(n1 => numbers.Select(n2 => n1*n2))
                .Where(IsPalindrome)
                .OrderByDescending(x => x)
                .First();
        }

        private bool IsPalindrome(int number)
        {
            int straight = number;
            int reverse = 0;
            while (number > 0)
            {
                int digit = number % 10;
                reverse = reverse * 10 + digit;
                number = number / 10;
            }
            return straight == reverse;
        }
    }
}
