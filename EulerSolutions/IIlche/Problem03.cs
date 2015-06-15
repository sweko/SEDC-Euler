using EulerEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutions.IIlche
{
    class Problem03: IProblemSolution
    {
        public int ProblemID
        {
            get { return 3; }
        }
        public long Execute()
        {
            long broj = 600851475143;
            long delitel = 2;
            long najgolemPrajm = 0;
            while (broj > 1)
            {
                while (broj % delitel == 0)
                {
                    broj /= delitel;
                    if (delitel > najgolemPrajm)
                    {
                        najgolemPrajm = delitel;
                    }
                    delitel = 2;
                }

                delitel++;

            }
            return najgolemPrajm;
        }
    }
}
