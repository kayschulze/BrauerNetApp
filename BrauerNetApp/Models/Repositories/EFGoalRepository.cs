using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrauerNetApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BrauerNetApp.Models
{
    public class EFGoalRepository : IGoalRepository
    {

        ApplicationDbContext db;

        public EFGoalRepository(ApplicationDbContext connection = null)
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

        public IQueryable<Goal> Goals
        { get { return db.Goals; } }

        public Goal Save(Goal goal)
        {
            db.Goals.Add(goal);
            db.SaveChanges();
            return goal;
        }

        public Goal Edit(Goal goal)
        {
            db.Entry(goal).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is Goal)
                    {
                        var databaseEntity = db.Goals
                            .FirstOrDefault(m => m.GoalId == ((Goal)entry.Entity).GoalId);
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

            return goal;
        }

        public void Remove(Goal goal)
        {
            db.Goals.Remove(goal);
            db.SaveChanges();
        }
    }
}
