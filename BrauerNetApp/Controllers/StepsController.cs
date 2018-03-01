using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BrauerNetApp.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty steps, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrauerNetApp.Controllers
{
    public class StepsController : Controller
    {
        private IStepRepository stepRepo;
        // GET: /<controller>/

        public StepsController(IStepRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.stepRepo = new EFStepRepository();
            }
            else
            {
                this.stepRepo = thisRepo;
            }
        }

        public IActionResult Index()
        {
            var stepsList = stepRepo.Steps
                .ToList();

            return View(stepsList);
        }

        public IActionResult DisplaySteps(int id)
        {
            var theseSteps = stepRepo.Steps
                .Include(x => x.ProjectId == id);
            return View(theseSteps);
        }

        public IActionResult CreateStep()
        {
            ViewBag.thisStep = stepRepo.Steps;
            return View();
        }

        [HttpPost]
        public IActionResult CreateStep(Step step)
        {
            stepRepo.Save(step);
            return RedirectToAction("Details", "Project", new { id = step.ProjectId });
        }

        public IActionResult EditStep(int id)
        {
            var thisStep = stepRepo.Steps
                .FirstOrDefault(x => x.StepId == id);
            return View(thisStep);
        }

        [HttpPost]
        public IActionResult EditStep(Step step)
        {
            stepRepo.Edit(step);
            //return Json(step);
            return RedirectToAction("Details", "Projects", new { id = step.ProjectId });
        }

        public IActionResult DeleteStep(int id)
        {
            var thisStep = stepRepo.Steps.FirstOrDefault(x => x.StepId == id);
            return View(thisStep);
        }

        [HttpPost, ActionName("DeleteStep")]
        public IActionResult DeleteConfirmed(int id)
        {
            var step = stepRepo.Steps.FirstOrDefault(x => x.StepId == id);
            Step thisStep = stepRepo.Steps.FirstOrDefault(x => x.StepId == id);
            stepRepo.Remove(thisStep);
            return RedirectToAction("Details", "Projects", new { id = step.ProjectId });
        }
    }
}

