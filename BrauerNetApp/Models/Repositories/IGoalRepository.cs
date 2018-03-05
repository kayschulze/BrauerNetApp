using System.Linq;

namespace BrauerNetApp.Models
{
    public interface IGoalRepository
    {
        IQueryable<Goal> Goals { get; }
        IQueryable<Project> Projects { get; }
        Goal Save(Goal goal);
        Goal Edit(Goal goal);
        void Remove(Goal goal);
    }
}
