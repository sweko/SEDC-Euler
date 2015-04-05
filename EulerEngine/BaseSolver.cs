using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerEngine
{
    class BaseSolver : ISolver
    {
        public string Name { get; set; }

        public List<IProblemSolution> Solutions { get; set; }

        public IEnumerable<IProblemSolution> GetSolutions()
        {
            return Solutions;
        }

        public BaseSolver()
        {
            Solutions = new List<IProblemSolution>();
        }
    }
}
