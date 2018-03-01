using System;
using System.Linq;
using BrauerNetApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BrauerNetApp.Models
{
    public class EFQUESTORRepository : IQUESTORRepository
    {
        ApplicationDbContext db;

        public EFQUESTORRepository(ApplicationDbContext connection = null)
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

        public IQueryable<QUESTOR> QUESTORs
        { get { return db.QUESTORs; } }

        public IQueryable<Goal> Goals
        { get { return db.Goals; } }

        public IQueryable<Module> Modules
        { get { return db.Modules; } }

        public IQueryable<Stakeholder> Stakeholders
        { get { return db.Stakeholders; } }

        public QUESTOR Save(QUESTOR questor)
        {
            db.QUESTORs.Add(questor);
            db.SaveChanges();
            return questor;
        }

        public QUESTOR Edit(QUESTOR questor)
        {
            db.Entry(questor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is QUESTOR)
                    {
                        var databaseEntity = db.QUESTORs
                            .FirstOrDefault(m => m.QUESTORId == ((QUESTOR)entry.Entity).QUESTORId);
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
            
            return questor;
        }

        public void Remove(QUESTOR questor)
        {
            db.QUESTORs.Remove(questor);
            db.SaveChanges();
        }
    }
}
