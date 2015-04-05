using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerEngine
{
    public interface ISolver
    {
        string Name { get; }
        IEnumerable<IProblemSolution> GetSolutions();
    }
}
