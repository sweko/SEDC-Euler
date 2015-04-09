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

            var result = Results.All.FirstOrDefault(s => s.Name == Solver);


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

            var filteredResults = new List<RunResults>();


            //should be done some other way...
            foreach (var result in runResults)
            {
                foreach (var problem in result.ProblemResults)
                {
                    if (problem.Value.ProblemID.ToString() == id)
                    {
                        filteredResults.Add(result);
                        break;
                    }
                }
            }

            filteredResults = filteredResults.Where(s => s.TotalSolved != 0).OrderBy(s => s.TotalElapsed).ToList();
           
                ViewBag.Problem = "Problem " + id;

            if (filteredResults == null)
            {
                Redirect("~/Error");
            }
            return View(filteredResults);
        }

        public ActionResult Reset()
        {
            Results.Recalculate();
            return Redirect("~/Home/Index");
        }

    }
}
