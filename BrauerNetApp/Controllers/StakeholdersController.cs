using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult Details(int id)
        {
            ViewBag.thisStakeholder = stakeholderRepo.Stakeholders;
            var thisStakeholder = stakeholderRepo.Stakeholders.FirstOrDefault(x => x.StakeholderId == id);

            return View(thisStakeholder);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Stakeholder stakeholder)
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
        public IActionResult Edit(Stakeholder stakeholder)
        {
            stakeholderRepo.Edit(stakeholder);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
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

