using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EulerEngine;
using EulerSolutions.SWeko;

namespace EulerRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Executor executor = new Executor();
            var solvers = Assembly
                .GetAssembly(typeof(SWekoSolver))
                .GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(ISolver)))
                .Select(Activator.CreateInstance)
                .Cast<ISolver>();

            foreach (var solver in solvers)
            {
                executor.RegisterSolver(solver);
            }

            var runResults = executor.RunSolvers().ToList();

            foreach (var runResult in runResults)
            {
                Console.WriteLine("{0}: solved {1}/50 in {2}ms", runResult.Name, runResult.TotalSolved, runResult.TotalElapsed);
                foreach (var pr in runResult.ProblemResults)
                {
                    Console.WriteLine("{0} ({2}): {1}", pr.Key, pr.Value.RunLength, pr.Value.Success);
                }
            }

            var resultsByProblem = runResults
                .SelectMany(rr => rr.ProblemResults.Values.Select(prr => new {prr.ProblemID, prr.RunLength, rr.Name}))
                .GroupBy(prr => prr.ProblemID)
                .Select(group => group.OrderBy(prr => prr.RunLength).First());

            foreach (var topResult in resultsByProblem)
            {
                Console.WriteLine("Problem {0}: {1}ms by {2}", topResult.ProblemID, topResult.RunLength.TotalMilliseconds, topResult.Name);
            }


        }
    }
}
