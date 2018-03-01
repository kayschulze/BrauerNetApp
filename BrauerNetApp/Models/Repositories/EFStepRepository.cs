using System;
using System.Linq;
using BrauerNetApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BrauerNetApp.Models
{
    public class EFStepRepository : IStepRepository
    {
        ApplicationDbContext db;

        public EFStepRepository(ApplicationDbContext connection = null)
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

        public IQueryable<Step> Steps
        { get { return db.Steps; } }

        public Step Save(Step step)
        {
            db.Steps.Add(step);
            db.SaveChanges();
            return step;
        }

        public Step Edit(Step step)
        {
            db.Entry(step).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is Step)
                    {
                        var databaseEntity = db.Steps
                            .FirstOrDefault(m => m.StepId == ((Step)entry.Entity).StepId);
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

            return step;
        }

        public void Remove(Step step)
        {
            db.Steps.Remove(step);
            db.SaveChanges();
        }
    }
}
