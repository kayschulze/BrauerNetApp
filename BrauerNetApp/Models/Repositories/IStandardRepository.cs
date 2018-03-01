using System.Linq;

namespace BrauerNetApp.Models
{
    public interface IStandardRepository
    {
        IQueryable<Standard> Standards { get; }
        IQueryable<Project> Projects { get; }
        Standard Save(Standard standard);
        Standard Edit(Standard standard);
        void Remove(Standard standard);
    }
}
