using EulerEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutions.IIlche
{
    public class Problem05: IProblemSolution
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
                broj += 2520;
            }
            return broj;
        }

        private bool resenie(long broj)
        {
            int brojac = 0;
            for (int i = 11; i <= 20; i++)
            {
                if (broj % i == 0)
                {
                    brojac++;
                }
            }
            return brojac == 10;
        }
    }
}
