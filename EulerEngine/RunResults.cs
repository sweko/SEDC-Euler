using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EulerEngine
{
    public class RunResults
    {
        public string Name { get; set; }
        public Dictionary<int, ProblemRunResult> ProblemResults { get; set; }

        public int TotalSolved
        {
            get { return ProblemResults.Count(kvp => kvp.Value.Success); }
        }

        public double TotalElapsed
        {
            get { return ProblemResults.Sum(kvp => kvp.Value.RunLength.TotalMilliseconds); }
        }

        public bool RunSuccess { get; set; }

        public RunResults()
        {
            ProblemResults = new Dictionary<int, ProblemRunResult>();
        }

        public string Message { get; set; }
    }
}
