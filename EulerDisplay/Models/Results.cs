using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EulerSolutions.SWeko;

namespace EulerEngine
{
    public abstract class Results
    {
        
        public static List<RunResults> All { get { return Run(); } }
        private static List<RunResults> Cached;
        private static int TotalSolved = 0;

        public static List<RunResults> Run()
        {
            
            
            Executor executor = new Executor();
            var solvers = Assembly
                .GetAssembly(typeof(SWekoSolver))
                .GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(ISolver)))
                .Select(Activator.CreateInstance)
                .Cast<ISolver>();

          

            Console.WriteLine("change");

            foreach (var solver in solvers)
            {
                executor.RegisterSolver(solver);
            }

            executor.RegisterSolver(new BaseSolver { Name = "Darko Ivanov" });
            executor.RegisterSolver(new BaseSolver { Name = "Darko Kostadinov" });
            executor.RegisterSolver(new BaseSolver { Name = "Goran Tozievski" });
            executor.RegisterSolver(new BaseSolver { Name = "Gorast Cvetkovski" });
            executor.RegisterSolver(new BaseSolver { Name = "Vladimir Totochevski" });
            executor.RegisterSolver(new BaseSolver { Name = "Jovan Cokleski" });
            executor.RegisterSolver(new BaseSolver { Name = "Petar Papalevski" });
            executor.RegisterSolver(new BaseSolver { Name = "Ilche Ivanovski" });
            executor.RegisterSolver(new BaseSolver { Name = "Kristijan Arsovski" });
            executor.RegisterSolver(new BaseSolver { Name = "Monika Jovanova" });
            executor.RegisterSolver(new BaseSolver { Name = "Ervin Jonuzoski" });
            executor.RegisterSolver(new BaseSolver { Name = "Mitko Miloshev" });
            executor.RegisterSolver(new BaseSolver { Name = "Martin Josifovski" });
            executor.RegisterSolver(new BaseSolver { Name = "Ice Jovanoski" });
            executor.RegisterSolver(new BaseSolver { Name = "Nikola Andreev" });
            executor.RegisterSolver(new BaseSolver { Name = "Darko Hristovski" });
            executor.RegisterSolver(new BaseSolver { Name = "Daniel Bibovski" });

            if (executor.NumberOfSolutions == TotalSolved) 
            {
                return Cached;
            }

            var runResults = executor.RunSolvers().OrderByDescending(rr => rr.TotalSolved).ThenBy(rr => rr.Name).ToList();
            Cached = runResults;
            TotalSolved = executor.NumberOfSolutions;
            return runResults;
        }

        public static void Recalculate()
        {
            TotalSolved = 0;
            Run();
        }
    }
}
