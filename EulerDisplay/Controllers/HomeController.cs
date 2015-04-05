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

            var runResults = executor.RunSolvers();

            ViewBag.Title = "Home Page";

            return View(runResults);
        }
    }
}
