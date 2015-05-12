using EulerEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutions.VTotocevski
{
    public class VTotocevskiSolver:ISolver
    {
        public string Name
        {
            get { return "Vladimir Totocevski"; }
        }

        public IEnumerable<IProblemSolution> GetSolutions()
        {
            List<IProblemSolution> VTsolutions = new List<IProblemSolution>()
            {
                new Problem1(),
                new Problem2(),
                new Problem3(),
                new Problem4(),
                new Problem5(),
                new Problem6(),
                new Problem7(),
                new Problem8(),
                new Problem9(),
                new Problem10(),
            };
            return VTsolutions;
        }
    }
}
