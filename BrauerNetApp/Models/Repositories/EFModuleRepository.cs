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

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is Module)
                    {
                        var databaseEntity = db.Modules
                            .FirstOrDefault(m => m.ModuleId == ((Module)entry.Entity).ModuleId);
                        var databaseEntry = db.Entry(databaseEntity);

                        foreach (var property in entry.Metadata.GetProperties())
                        {
                            var proposedValue = entry.Property(property.Name).CurrentValue;
                            var originalValue = entry.Property(property.Name).OriginalValue;
                            var databaseValue = databaseEntry.Property(property.Name).CurrentValue;

                            entry.Property(property.Name).OriginalValue = databaseEntry.Property(property.Name).CurrentValue;
                        }
                    }
                    else
                    {
                        throw new NotSupportedException("Don't know how to handle concurrency conflicts for " + entry.Metadata.Name);
                    }

                    db.SaveChanges();
                }
            }
            
            return module;
        }

        public void Remove(Module module)
        {
            db.Modules.Remove(module);
            db.SaveChanges();
        }
    }
}
