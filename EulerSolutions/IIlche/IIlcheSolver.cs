using EulerEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSolutions.IIlche
{
    public class IIlcheSolver:ISolver
    {
        public string Name
        {
            get { return "Ilche Ivanovski"; }
        }
        public IEnumerable<IProblemSolution> GetSolutions()
        {
            List<IProblemSolution> IISolutioins = new List<IProblemSolution>()
            {
                new Problem01(),
                new Problem02(),
                new Problem03(),
                new Problem04(),
                new Problem05(),
                //new Problem06(),
                //new Problem07(),
                //new Problem08(),
                //new Problem09(),
                //new Problem10(),
             };
            return IISolutioins;
        }
    }
}
