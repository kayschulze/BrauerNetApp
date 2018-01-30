using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrauerNetApp.Models
{
    public interface IGoalRepository
    {
        IQueryable<Goal> Goals { get; }
        Goal Save(Goal goal);
        Goal Edit(Goal goal);
        void Remove(Goal goal);
    }
}
