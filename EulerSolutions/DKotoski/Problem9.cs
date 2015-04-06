using EulerEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutions.DKotoski
{
    class Problem9:IProblemSolution
    {
        public int ProblemID
        {
            get { return 9; }
        }

        public long Execute()
        {
            var theTriplets = GetTriplets().First(x => (x[0] + x[1] + x[2]) == 1000);
            return (theTriplets[0] * theTriplets[1] * theTriplets[2]);
        }

        public IEnumerable<List<long>> GetTriplets()
        {
            for (long i = 1; i < 1000; i++)
            {
                for (long j = 1; j < 1000; j++)
                {
                    if(Math.Sqrt(i*i+j*j)==Math.Floor(Math.Sqrt(i*i+j*j)))
                        yield return new List<long>(){i,j,(long)Math.Sqrt(i*i+j*j)};
                }
            }
        }
    }
}
