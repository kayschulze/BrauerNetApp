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
            var projectsList = db.Projects
                .Include(s => s.Steps)
                .Include(r => r.Responses)
                .Include(s => s.Standards)
                .ToList();

            return View(projectsList);
        }

        public IActionResult DetailsProject(int id)
        {
            ViewBag.thisProject = projectRepo.Projects;
            var thisProject = db.Projects
                .Include(s => s.Steps)
                .Include(r => r.Responses)
                .Include(s => s.Standards)
                .FirstOrDefault(x => x.ProjectId == id);
            return View(thisProject);
        }

        public IActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProject(Project project)
        {
            projectRepo.Save(project);
            var thisProject = projectRepo.Projects.FirstOrDefault(x => x.ProjectId == project.ProjectId);
            return RedirectToAction("Edit", "QUESTORs", new { id = thisProject.ModuleId });
        }

        public IActionResult EditProject(int id)
        {
            var project = projectRepo.Projects.FirstOrDefault(x => x.ProjectId == id);
            var thisProject = projectRepo.Projects
                .Include(s => s.Steps)
                .Include(r => r.Responses)
                .Include(s => s.Standards)
                .Include(m => m.Module)
                .ThenInclude(q => q.QUESTORId)
                .FirstOrDefault(x => x.ProjectId == id);
            return View(thisProject);
        }

        [HttpPost]
        public IActionResult EditProject(Project project)
        {
            projectRepo.Edit(project);
            var module = project.ModuleId;
            return RedirectToAction("Edit", "QUESTORs", new { id = project.Module.QUESTORId });
        }

        public IActionResult DeleteProject(int id)
        {
            var thisProject = projectRepo.Projects
                .FirstOrDefault(x => x.ProjectId == id);
            return View(thisProject);
        }

        [HttpPost, ActionName("DeleteProject")]
        public IActionResult DeleteConfirmed(int id)
        {
            var project = projectRepo.Projects //may not need
                .FirstOrDefault(x => x.ProjectId == id);
            Project thisProject = projectRepo.Projects.FirstOrDefault(x => x.ProjectId == id);
            projectRepo.Remove(thisProject);
            return RedirectToAction("Edit", "QUESTORs", new { id = project.Module.QUESTORId });
        }
    }
}

