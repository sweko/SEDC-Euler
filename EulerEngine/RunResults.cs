using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EulerEngine
{
    public class RunResults
    {
        public string Name { get; set; }
        public Dictionary<int, bool> ProblemResults { get; set; }

        public int TotalSolved
        {
            get { return ProblemResults.Count(kvp => kvp.Value); }
        }
        public bool RunSuccess { get; set; }

        public RunResults()
        {
            ProblemResults = new Dictionary<int, bool>();
        }

        public string Message { get; set; }
    }
}
