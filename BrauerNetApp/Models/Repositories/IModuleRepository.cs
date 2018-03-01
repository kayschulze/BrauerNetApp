using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrauerNetApp.Models
{
    public interface IModuleRepository
    {
        IQueryable<Module> Modules { get; }
        IQueryable<Project> Projects { get; }
        IQueryable<QUESTOR> QUESTORs { get; }
        Module Save(Module module);
        Module Edit(Module module);
        void Remove(Module module);
    }
}
