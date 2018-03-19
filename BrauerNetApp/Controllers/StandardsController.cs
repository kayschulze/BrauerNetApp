using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrauerNetApp.Models;

// For more information on enabling MVC for empty standards, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrauerNetApp.Controllers
{
    public class StandardsController : Controller
    {
        private IStandardRepository standardRepo;
        // GET: /<controller>/

        public StandardsController(IStandardRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.standardRepo = new EFStandardRepository();
            }
            else
            {
                this.standardRepo = thisRepo;
            }
        }

        public IActionResult Index()
        {
            var standardsList = standardRepo.Standards.ToList();

            return View(standardsList);
        }

        public IActionResult Details(int id)
        {
            ViewBag.thisStandard = standardRepo.Standards;
            var thisStandard = standardRepo.Standards.FirstOrDefault(x => x.StandardId == id);

            return View(thisStandard);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Standard standard)
        {
            standardRepo.Save(standard);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisStandard = standardRepo.Standards.FirstOrDefault(x => x.StandardId == id);
            return View(thisStandard);
        }

        [HttpPost]
        public IActionResult Edit(Standard standard)
        {
            standardRepo.Edit(standard);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisStandard = standardRepo.Standards.FirstOrDefault(x => x.StandardId == id);
            return View(thisStandard);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Standard thisStandard = standardRepo.Standards.FirstOrDefault(x => x.StandardId == id);
            standardRepo.Remove(thisStandard);
            return RedirectToAction("Index");
        }

        public IActionResult AddStandard(int id)
        {
            ViewBag.StandardId = new SelectList(standardRepo.Standards, "StandardId", "Identifier");
            var thisStandard = standardRepo.Standards
                .FirstOrDefault(standard => standard.StandardId == id);
            return View(thisStandard);
        }

        [HttpPost]
        public IActionResult AddStandard(Standard standard)
        {

            return View("Index");
        }
    }
}

