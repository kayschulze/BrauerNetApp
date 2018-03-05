using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BrauerNetApp.Models;

// For more information on enabling MVC for empty goals, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrauerNetApp.Controllers
{
    public class GoalsController : Controller
    {
        private IGoalRepository goalRepo;
        // GET: /<controller>/

        public GoalsController(IGoalRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.goalRepo = new EFGoalRepository();
            }
            else
            {
                this.goalRepo = thisRepo;
            }
        }

        public IActionResult Index()
        {
            var goalsList = goalRepo.Goals
                .ToList();

            return View(goalsList);
        }

        public IActionResult DisplayGoal(int id)
        {
            ViewBag.thisGoal = goalRepo.Goals;
            var thisGoal = goalRepo.Goals
                .FirstOrDefault(x => x.GoalId == id);

            return View(thisGoal);
        }

        public IActionResult CreateGoal()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateGoal(Goal goal)
        {
            goalRepo.Save(goal);
            return RedirectToAction("Edit", "QUESTORs", new { id = goal.QUESTORId });
        }

        public IActionResult EditGoal(int id)
        {
            var thisGoal = goalRepo.Goals
                .FirstOrDefault(x => x.GoalId == id);
            return View(thisGoal);
        }

        [HttpPost]
        public IActionResult EditGoal(Goal goal)
        {
            goalRepo.Edit(goal);
            return RedirectToAction("Edit", "QUESTORs", new { id = goal.QUESTORId });
        }

        public IActionResult DeleteGoal(int id)
        {
            var thisGoal = goalRepo.Goals
                .FirstOrDefault(x => x.GoalId == id);
            return View(thisGoal);
        }

        [HttpPost, ActionName("DeleteGoal")]
        public IActionResult DeleteConfirmed(int id)
        {
            var goal = goalRepo.Goals.FirstOrDefault(x => x.GoalId == id);
            Goal thisGoal = goalRepo.Goals.FirstOrDefault(x => x.GoalId == id);
            goalRepo.Remove(thisGoal);
            return RedirectToAction("Edit", "QUESTORs", new { id = goal.QUESTORId });
        }
    }
}

