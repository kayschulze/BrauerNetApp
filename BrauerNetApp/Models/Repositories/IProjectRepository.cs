using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrauerNetApp.Models
{
    public interface IProjectRepository
    {
        IQueryable<Project> Projects { get; }
        IQueryable<Module> Modules { get; }
        IQueryable<Step> Steps { get; }
        IQueryable<Response> Responses { get; }
        IQueryable<Standard> Standards { get; }
        Project Save(Project project);
        Project Edit(Project project);
        void Remove(Project project);
    }
}
