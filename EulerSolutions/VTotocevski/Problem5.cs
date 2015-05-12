using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerEngine;

namespace EulerSolutions.VTotocevski
{
    class Problem5 : IProblemSolution
    {
        public int ProblemID
        {
            get { return 5; }
        }

        public long Execute()
        {
            long broj = 2520;
            while (resenie(broj) == false)
            {
                broj+=2520;
            }
            return broj;
        }

        private bool resenie(long broj)
        {
            int brojac = 0;
            for (int i = 11; i <= 20; i++)
            {
                if (broj%i == 0)
                {
                    brojac++;
                }
            }
            return brojac == 10;
        }
    }
}
