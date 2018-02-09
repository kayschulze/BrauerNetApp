using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrauerNetApp.Models
{
    public class ModuleStep
    {
        public virtual int ModuleId { get; set; }
        public virtual Module Module { get; set; }

        public virtual int StepId { get; set; }
        public virtual Step Step { get; set; }
    }
}
