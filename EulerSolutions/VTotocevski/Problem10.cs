using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using EulerEngine;

namespace EulerSolutions.VTotocevski
{
    class Problem10 : IProblemSolution
    {
        public int ProblemID
        {
            get { return 10; }
        }

        public long Execute()
        {
            long broj = 1;
            List<long> lista = new List<long>();
            long primes = 0;
            while (broj <= 2000000)
            {
                if (Problem7.IsPrime((int)broj))
                {
                    lista.Add(broj);
                }
                broj++;
            }
            primes = lista.Sum();
            return  primes;
        }
    }
}
