using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrauerNetApp.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty modules, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrauerNetApp.Controllers
{
    public class ModulesController : Controller
    {
        private IModuleRepository moduleRepo;
        // GET: /<controller>/

        public ModulesController(IModuleRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.moduleRepo = new EFModuleRepository();
            }
            else
            {
                this.moduleRepo = thisRepo;
            }
        }

        public IActionResult Index()
        {
            var modulesList = moduleRepo.Modules
                .ToList();

            return View(modulesList);
        }

        public IActionResult DisplayModule(int id)
        {
            ViewBag.thisModule = moduleRepo.Modules;
            var thisModule = moduleRepo.Modules
                .FirstOrDefault(x => x.QUESTORId == id);
            return View(thisModule);
        }

        public IActionResult CreateModule()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateModule(Module module)
        {
            moduleRepo.Save(module);
            return RedirectToAction("Edit", "QUESTORs", new { id = module.QUESTORId });
        }

        public IActionResult EditModule(int id)
        {
            var thisModule = moduleRepo.Modules
                .FirstOrDefault(x => x.ModuleId == id);
            return View(thisModule);
        }

        [HttpPost]
        public IActionResult EditModule(Module module)
        {
            moduleRepo.Edit(module);
            return RedirectToAction("Edit", "Projects", new { id = module.QUESTORId });
        }

        public IActionResult DeleteModule(int id)
        {
            var thisModule = moduleRepo.Modules
                .FirstOrDefault(x => x.ModuleId == id);
            return View(thisModule);
        }

        [HttpPost, ActionName("DeleteModule")]
        public IActionResult DeleteConfirmed(int id)
        {
            var module = moduleRepo.Modules.FirstOrDefault(x => x.ModuleId == id);
            Module thisModule = moduleRepo.Modules.FirstOrDefault(x => x.ModuleId == id);
            moduleRepo.Remove(thisModule);
            return RedirectToAction("Edit", "QUESTORs", new { id = module.QUESTORId });
        }
    }
}

