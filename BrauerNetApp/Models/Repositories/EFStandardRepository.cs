﻿using System.Linq;
using BrauerNetApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BrauerNetApp.Models
{
    public class EFStandardRepository : IStandardRepository
    {

        ApplicationDbContext db;

        public EFStandardRepository(ApplicationDbContext connection = null)
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

        public IQueryable<Standard> Standards
        { get { return db.Standards; } }

        public IQueryable<Project> Projects
        { get { return db.Projects; } }

        public Standard Save(Standard standard)
        {
            db.Standards.Add(standard);
            db.SaveChanges();
            return standard;
        }

        public Standard Edit(Standard standard)
        {
            db.Entry(standard).State = EntityState.Modified;
            db.SaveChanges();
            return standard;
        }

        public void Remove(Standard standard)
        {
            db.Standards.Remove(standard);
            db.SaveChanges();
        }
    }
}
