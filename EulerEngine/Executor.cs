using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerEngine
{
    public class Executor
    {
        private readonly List<ISolver> solvers;
        private readonly Dictionary<int, long> solutions;

        #region init
        public Executor()
        {
            solvers = new List<ISolver>();
            solutions = new Dictionary<int, long>{
                {1, 233168},{2, 4613732},{3, 6857},{4, 906609},{5, 232792560},
                {6, 25164150},{7, 104743},{8, 23514624000},{9, 31875000},{10, 142913828922},
                {11, 70600674},{12, 76576500},{13, 5537376230},{14, 837799},{15, 137846528820},
                {16, 1366},{17, 21124},{18, 1074},{19, 171},{20, 648},
                {21, 31626},{22, 871198282},{23, 4179871},{24, 2783915460},{25, 4782},
                {26, 983},{27, -59231},{28, 669171001},{29, 9183},{30, 443839},
                {31, 73682},{32, 45228},{33, 100},{34, 40730},{35, 55},
                {36, 872187},{37, 748317},{38, 932718654},{39, 840},{40, 210},
                {41, 7652413},{42, 162},{43, 16695334890},{44, 5482660},{45, 1533776805},
                {46, 5777},{47, 134043},{48, 9110846700},{49, 296962999629},{50, 997651}
            };
        }

        #endregion

        public Executor RegisterSolver(ISolver solver)
        {
            solvers.Add(solver);
            return this;
        }

        public IEnumerable<RunResults> RunSolvers()
        {
            return solvers.Select(RunSolver);
        }

        private RunResults RunSolver(ISolver solver)
        {
            RunResults result = new RunResults {Name = solver.Name, RunSuccess = true};
            foreach (var solution in solver.GetSolutions().Where(s => solutions.ContainsKey(s.ProblemID)))
            {
                try
                {
                    var solverResult = solution.Execute();                   
                    var actualResult = solutions[solution.ProblemID];
                    result.ProblemResults.Add(solution.ProblemID, actualResult == solverResult);
                }
                catch (Exception ex)
                {
                    result.RunSuccess = false;
                    result.Message = string.Format("Exception running problem {0}: {1}", solution.ProblemID, ex.Message);
                    break;
                }
            }
            return result;
        }
    }
}
