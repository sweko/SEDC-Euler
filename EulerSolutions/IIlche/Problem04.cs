using EulerEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutions.IIlche
{
    class Problem04: IProblemSolution
    {
        public int ProblemID
        {
            get { return 4; }
        }
        public long Execute()
        {
            return GetInt().Where(x=>IsPalindrom(x)).Max();
        }

        public IEnumerable<Int32> GetInt()
        {
            for (int i = 900; i < 999; i++)
            {
                for (int j = 900; j < 999; j++)
                {
                    yield return i* j;
                }
            }
        }
        public bool IsPalindrom(int x)
        {
            int reversed = 0;
            int str = x;
            while (str > 0)
            {
                reversed *= 10;
                reversed += str % 10;
                str /= 10;
            }
            return reversed == x;
        }
    }
}
