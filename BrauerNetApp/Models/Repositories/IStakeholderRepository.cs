using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrauerNetApp.Models
{
    public interface IStakeholderRepository
    {
        IQueryable<Stakeholder> Stakeholders { get; }
        Stakeholder Save(Stakeholder stakeholder);
        Stakeholder Edit(Stakeholder stakeholder);
        void Remove(Stakeholder stakeholder);
    }
}
