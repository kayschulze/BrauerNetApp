using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrauerNetApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BrauerNetApp.Models
{
    public class EFModuleRepository : IModuleRepository
    {

        ApplicationDbContext db;

        public EFModuleRepository(ApplicationDbContext connection = null)
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

        public IQueryable<Module> Modules
        { get { return db.Modules; } }

        public IQueryable<Project> Projects
        { get { return db.Projects; } }

        public Module Save(Module module)
        {
            db.Modules.Add(module);
            db.SaveChanges();
            return module;
        }

        public Module Edit(Module module)
        {
            db.Entry(module).State = EntityState.Modified;
            db.SaveChanges();
            return module;
        }

        public void Remove(Module module)
        {
            db.Modules.Remove(module);
            db.SaveChanges();
        }
    }
}
