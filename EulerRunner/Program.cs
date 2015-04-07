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

            var runResults = executor.RunSolvers();

            foreach (var runResult in runResults)
            {
                Console.WriteLine("{0}: solved {1}/50", runResult.Name, runResult.TotalSolved);
            }
        }
    }
}
