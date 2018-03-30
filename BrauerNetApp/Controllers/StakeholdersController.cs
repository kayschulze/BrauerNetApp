using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BrauerNetApp.Models;

// For more information on enabling MVC for empty stakeholders, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrauerNetApp.Controllers
{
    public class StakeholdersController : Controller
    {
        private IStakeholderRepository stakeholderRepo;
        // GET: /<controller>/

        public StakeholdersController(IStakeholderRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.stakeholderRepo = new EFStakeholderRepository();
            }
            else
            {
                this.stakeholderRepo = thisRepo;
            }
        }

        public IActionResult Index()
        {
            var stakeholdersList = stakeholderRepo.Stakeholders.ToList();

            return View(stakeholdersList);
        }

        public IActionResult DetailsStakeholder(int id)
        {
            ViewBag.thisStakeholder = stakeholderRepo.Stakeholders;
            var thisStakeholder = stakeholderRepo.Stakeholders.FirstOrDefault(x => x.StakeholderId == id);

            return View(thisStakeholder);
        }

        public IActionResult CreateStakeholder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateStakeholder(Stakeholder stakeholder)
        {
            stakeholderRepo.Save(stakeholder);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisStakeholder = stakeholderRepo.Stakeholders.FirstOrDefault(x => x.StakeholderId == id);
            return View(thisStakeholder);
        }

        [HttpPost]
        public IActionResult EditStakeholder(Stakeholder stakeholder)
        {
            stakeholderRepo.Edit(stakeholder);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteStakeholder(int id)
        {
            var thisStakeholder = stakeholderRepo.Stakeholders.FirstOrDefault(x => x.StakeholderId == id);
            return View(thisStakeholder);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Stakeholder thisStakeholder = stakeholderRepo.Stakeholders.FirstOrDefault(x => x.StakeholderId == id);
            stakeholderRepo.Remove(thisStakeholder);
            return RedirectToAction("Index");
        }
    }
}

