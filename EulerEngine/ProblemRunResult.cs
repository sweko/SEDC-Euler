using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EulerEngine
{
    public class ProblemRunResult
    {
        public int ProblemID { get; set; }
        public bool Success { get; set; }
        //public string Message { get; set; }
        public TimeSpan RunLength { get; set; }
    }
}
