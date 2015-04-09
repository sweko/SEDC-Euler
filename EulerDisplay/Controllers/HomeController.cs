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
            var runResults = Results.All;

            ViewBag.Title = "Student Leaderboard";

            return View(runResults);
        }

        public ActionResult Personal(string Solver)
        {
            

            ViewBag.Title = "Student Leaderboard";

            ViewBag.Title = "Student Leaderboard";

            var runResults = Results.All;

            var result = runResults.FirstOrDefault(s => s.Name == Solver);

            if (result == null)
            {
                Redirect("~/Error");
            }

            return View(result);
        }

        public ActionResult Solution(string id)
        {
            var runResults = Results.All;

            ViewBag.Title = "Student Leaderboard";

            ViewBag.Title = "Student Leaderboard";

            var result = runResults.Select(s => { s.ProblemResults = s.ProblemResults.Where(p => p.Value.ProblemID.ToString() == id).ToDictionary(p => p.Key, p => p.Value); return s; }).Where(s=>s.TotalSolved!=0).OrderBy(s=>s.TotalElapsed).ToList();

            ViewBag.Problem = "Problem " + id;

            if (result == null)
            {
                Redirect("~/Error");
            }
            return View(result);
        }

        public ActionResult Reset()
        {
            Results.Recalculate();
            return Redirect("~/Home/Index");
        }

    }
}
