using System.Linq;

namespace BrauerNetApp.Models
{
    public interface IStepRepository
    {
        IQueryable<Project> Projects { get; }
        IQueryable<Step> Steps { get; }
        Step Save(Step step);
        Step Edit(Step step);
        void Remove(Step step);
    }
}