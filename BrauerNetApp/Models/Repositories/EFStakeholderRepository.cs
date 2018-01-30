using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrauerNetApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BrauerNetApp.Models
{
    public class EFStakeholderRepository : IStakeholderRepository
    {

        ApplicationDbContext db;

        public EFStakeholderRepository(ApplicationDbContext connection = null)
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

        public IQueryable<Stakeholder> Stakeholders
        { get { return db.Stakeholders; } }

        public Stakeholder Save(Stakeholder stakeholder)
        {
            db.Stakeholders.Add(stakeholder);
            db.SaveChanges();
            return stakeholder;
        }

        public Stakeholder Edit(Stakeholder stakeholder)
        {
            db.Entry(stakeholder).State = EntityState.Modified;
            db.SaveChanges();
            return stakeholder;
        }

        public void Remove(Stakeholder stakeholder)
        {
            db.Stakeholders.Remove(stakeholder);
            db.SaveChanges();
        }
    }
}
