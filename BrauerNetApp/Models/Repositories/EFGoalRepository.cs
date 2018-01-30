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
            db.SaveChanges();
            return goal;
        }

        public void Remove(Goal goal)
        {
            db.Goals.Remove(goal);
            db.SaveChanges();
        }
    }
}
