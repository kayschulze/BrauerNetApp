using System;
using System.Linq;
using BrauerNetApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BrauerNetApp.Models
{
    public class EFResponseRepository : IResponseRepository
    {
        ApplicationDbContext db;

        public EFResponseRepository(ApplicationDbContext connection = null)
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

        public IQueryable<Response> Responses
        { get { return db.Responses; } }

        public IQueryable<Project> Projects
        { get { return db.Projects; } }

        public Response Save(Response response)
        {
            db.Responses.Add(response);
            db.SaveChanges();
            return response;
        }

        public Response Edit(Response response)
        {
            db.Entry(response).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is Response)
                    {
                        var databaseEntity = db.Responses
                            .FirstOrDefault(m => m.ResponseId == ((Response)entry.Entity).ResponseId);
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
            
            return response;
        }

        public void Remove(Response response)
        {
            db.Responses.Remove(response);
            db.SaveChanges();
        }
    }
}
