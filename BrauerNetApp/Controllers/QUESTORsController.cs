using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrauerNetApp.Models;
using Microsoft.EntityFrameworkCore;
using BrauerNetApp.Data;

// For more information on enabling MVC for empty questors, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrauerNetApp.Controllers
{
    public class QUESTORsController : Controller
    {
        private IQUESTORRepository questorRepo;
        // GET: /<controller>/

        public QUESTORsController(IQUESTORRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.questorRepo = new EFQUESTORRepository();
            }
            else
            {
                this.questorRepo = thisRepo;
            }
        }

        ApplicationDbContext db = new ApplicationDbContext();

        public IActionResult Index()
        {
            var questorsList = db.QUESTORs
                .ToList();

            return View(questorsList);
        }

        public IActionResult Details(int id)
        {
            ViewBag.thisQUESTOR = questorRepo.QUESTORs;
            var thisQUESTOR = questorRepo.QUESTORs
                .Include(g => g.Goals)
                .Include(m => m.Modules)
                .ThenInclude(p => p.Projects)
                .ThenInclude(s => s.Steps)
                .Include(m => m.Modules)
                .ThenInclude(p => p.Projects)
                .ThenInclude(s => s.Responses)
                //.Include(m => m.Modules)
                //.ThenInclude(p => p.Projects)
                //.ThenInclude(s => s.Standards)
                .FirstOrDefault(x => x.QUESTORId == id);
            return View(thisQUESTOR);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(QUESTOR questor)
        {
            questorRepo.Save(questor);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var questor = questorRepo.QUESTORs
                .FirstOrDefault(x => x.QUESTORId == id);
            //ViewBag.thisQUESTOR = questorRepo.QUESTORs;
            var thisQUESTOR = questorRepo.QUESTORs
                .Include(g => g.Goals)
                .Include(m => m.Modules)
                .ThenInclude(p => p.Projects)
                .ThenInclude(s => s.Steps)
                .Include(m => m.Modules)
                .ThenInclude(p => p.Projects)
                .ThenInclude(s => s.Responses)
                .Include(m => m.Modules)
                //.ThenInclude(p => p.Projects)
                //.ThenInclude(ps => ps.ProjectStandards)
                //.ThenInclude(s => s.Standard)
                .FirstOrDefault(x => x.QUESTORId == id);
            return View(thisQUESTOR);
        }

        [HttpPost]
        public IActionResult Edit(QUESTOR questor)
        {
            questorRepo.Edit(questor);
            ViewBag.thisQUESTOR = questorRepo.QUESTORs
                .Include(g => g.Goals)
                .Include(m => m.Modules)
                .ThenInclude(p => p.Projects)
                .ThenInclude(s => s.Steps)
                .Include(m => m.Modules)
                .ThenInclude(p => p.Projects)
                .ThenInclude(s => s.Responses)
                .Include(m => m.Modules)
                .FirstOrDefault(x => x.QUESTORId == questor.QUESTORId);
            return RedirectToAction("Edit", "QUESTORs", new { id = questor.QUESTORId });
        }

        public IActionResult Delete(int id)
        {
            var thisQUESTOR = questorRepo.QUESTORs.FirstOrDefault(x => x.QUESTORId == id);
            return View(thisQUESTOR);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            QUESTOR thisQUESTOR = questorRepo.QUESTORs.FirstOrDefault(x => x.QUESTORId == id);
            questorRepo.Remove(thisQUESTOR);
            return RedirectToAction("Index");
        }
    }
}

