using EulerEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutions.DKotoski
{
    class Problem6:IProblemSolution
    {

        public int ProblemID
        {
            get { return 6; }
        }

        public long Execute()
        {
            var tmp = 1.To(100).Aggregate((x,y)=>x+y);
            return   tmp*tmp - 1.To(100).Select(x=>x*x).Sum();
        }
    }
}
