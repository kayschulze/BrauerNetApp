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

        public IActionResult Details(int id)
        {
            ViewBag.thisModule = moduleRepo.Modules;
            var thisModule = moduleRepo.Modules
                .FirstOrDefault(x => x.ModuleId == id);
            return View(thisModule);
        }

        public IActionResult CreateModule()
        {
            ViewBag.thisProject = moduleRepo.Projects;
            return View();
        }

        [HttpPost]
        public IActionResult CreateModule(Module module)
        {
            moduleRepo.Save(module);
            return RedirectToAction("Details", "Projects", new { id = module.ProjectId });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Module module)
        {
            moduleRepo.Save(module);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisModule = moduleRepo.Modules
                .FirstOrDefault(x => x.ModuleId == id);
            return View(thisModule);
        }

        [HttpPost]
        public IActionResult Edit(Module module)
        {
            moduleRepo.Edit(module);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisModule = moduleRepo.Modules.FirstOrDefault(x => x.ModuleId == id);
            return View(thisModule);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Module thisModule = moduleRepo.Modules.FirstOrDefault(x => x.ModuleId == id);
            moduleRepo.Remove(thisModule);
            return RedirectToAction("Index");
        }
    }
}

