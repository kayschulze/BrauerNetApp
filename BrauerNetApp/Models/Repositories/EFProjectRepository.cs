using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrauerNetApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BrauerNetApp.Models
{
    public class EFProjectRepository : IProjectRepository
    {

        ApplicationDbContext db;

        public EFProjectRepository(ApplicationDbContext connection = null)
        {
            if (connection == null)
            {
                this.db = new ApplicationDbContext();
            }
            else
            {
                this.db = connection;
            }
        }

        public IQueryable<Project> Projects
        { get { return db.Projects; } }

        public Project Save(Project project)
        {
            db.Projects.Add(project);
            db.SaveChanges();
            return project;
        }

        public Project Edit(Project project)
        {
            db.Entry(project).State = EntityState.Modified;
            db.SaveChanges();
            return project;
        }

        public void Remove(Project project)
        {
            db.Projects.Remove(project);
            db.SaveChanges();
        }
    }
}
