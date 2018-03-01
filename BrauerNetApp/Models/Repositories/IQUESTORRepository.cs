using System.Linq;

namespace BrauerNetApp.Models
{
    public interface IQUESTORRepository
    {
        IQueryable<QUESTOR> QUESTORs { get; }
        IQueryable<Goal> Goals { get; }
        IQueryable<Module> Modules { get; }
        IQueryable<Stakeholder> Stakeholders { get; }
        QUESTOR Save(QUESTOR questor);
        QUESTOR Edit(QUESTOR questor);
        void Remove(QUESTOR questor);
    }
}
