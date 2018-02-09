using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrauerNetApp.Models;
using Microsoft.EntityFrameworkCore;
using BrauerNetApp.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrauerNetApp.Controllers
{
    public class ProjectsController : Controller
    {
        private IProjectRepository projectRepo;
        // GET: /<controller>/

        public ProjectsController(IProjectRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.projectRepo = new EFProjectRepository();
            }
            else
            {
                this.projectRepo = thisRepo;
            }
        }

        ApplicationDbContext db = new ApplicationDbContext();

        public IActionResult Index()
        {
            var projectsList = projectRepo.Projects
                .Include(p => p.GoalProjects)
                .ThenInclude(j => j.Goal)
                .ToList();

            return View(projectsList);
        }

        public IActionResult Details(int id)
        {
            //ViewBag.thisProject = projectRepo.Projects;
            var thisProject = db.Projects
                .Include(p => p.GoalProjects)
                .ThenInclude(j => j.Goal)
                .Include(mp => mp.ModuleProjects)
                .ThenInclude(m => m.Module)
                .FirstOrDefault(x => x.ProjectId == id);
            return View(thisProject);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Project project)
        {
            projectRepo.Save(project);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisProject = projectRepo.Projects
                .Include(p => p.GoalProjects)
                .ThenInclude(j => j.Goal)
                .FirstOrDefault(x => x.ProjectId == id);
            return View(thisProject);
        }

        [HttpPost]
        public IActionResult Edit(Project project)
        {
            projectRepo.Edit(project);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisProject = projectRepo.Projects.FirstOrDefault(x => x.ProjectId == id);
            return View(thisProject);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Project thisProject = projectRepo.Projects.FirstOrDefault(x => x.ProjectId == id);
            projectRepo.Remove(thisProject);
            return RedirectToAction("Index");
        }
    }
}

