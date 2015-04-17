using System;
using System.Linq;
using System.Web.Mvc;
using EulerDisplay.Models;

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

            var problemId = int.Parse(id);

            var filteredResults = runResults.SelectMany(rr => rr.ProblemResults.Select(pr => new ProblemViewModel
            {
                ProblemID = pr.Key,
                TotalElapsed = pr.Value.RunLength,
                Solver = rr.Name
            })).Where(pr => pr.ProblemID == problemId).OrderBy(pr => pr.TotalElapsed);

            return View(filteredResults);
        }

        public ActionResult Reset()
        {
            Results.Recalculate();
            return Redirect("~/Home/Index");
        }

    }
}
