using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrauerNetApp.Models
{
    public interface IStandardRepository
    {
        IQueryable<Standard> Standards { get; }
        Standard Save(Standard standard);
        Standard Edit(Standard standard);
        void Remove(Standard standard);
    }
}
