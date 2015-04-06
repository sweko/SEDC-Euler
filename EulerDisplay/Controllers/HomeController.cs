using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using EulerEngine;
using EulerSolutions.SWeko;

namespace EulerDisplay.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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

            executor.RegisterSolver(new BaseSolver { Name = "Darko Ivanov" });
            executor.RegisterSolver(new BaseSolver { Name = "Darko Kostadinov" });
            executor.RegisterSolver(new BaseSolver { Name = "Darko Kotoski" });
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
            
            var runResults = executor.RunSolvers().OrderByDescending(rr => rr.TotalSolved).ThenBy(rr => rr.Name);

            ViewBag.Title = "Home Page";

            return View(runResults);
        }
    }
}
