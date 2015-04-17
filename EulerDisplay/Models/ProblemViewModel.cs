using System;
using System.Linq;

namespace EulerDisplay.Models
{
    public class ProblemViewModel
    {
        public int ProblemID { get; set; }
        public TimeSpan TotalElapsed { get; set; }
        public string Solver { get; set; }
    }
}
