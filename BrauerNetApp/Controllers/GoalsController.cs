using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var goalsList = goalRepo.Goals.ToList();

            return View(goalsList);
        }

        public IActionResult Details(int id)
        {
            ViewBag.thisGoal = goalRepo.Goals;
            var thisGoal = goalRepo.Goals.FirstOrDefault(x => x.GoalId == id);

            return View(thisGoal);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Goal goal)
        {
            goalRepo.Save(goal);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisGoal = goalRepo.Goals.FirstOrDefault(x => x.GoalId == id);
            return View(thisGoal);
        }

        [HttpPost]
        public IActionResult Edit(Goal goal)
        {
            goalRepo.Edit(goal);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisGoal = goalRepo.Goals.FirstOrDefault(x => x.GoalId == id);
            return View(thisGoal);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Goal thisGoal = goalRepo.Goals.FirstOrDefault(x => x.GoalId == id);
            goalRepo.Remove(thisGoal);
            return RedirectToAction("Index");
        }
    }
}

