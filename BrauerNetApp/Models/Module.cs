using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrauerNetApp.Models
{
    [Table("Modules")]
    public class Module
    {
        [Key]
        public int ModuleId { get; set; }
        public string Title { get; set; }
        public List<Step> Steps { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public virtual List<ModuleProject> ModuleProjects { get; set; }

        public Module()
        {

        }

        public Module(string title, List<Step> steps, int moduleId = 0)
        {
            Title = title;
            Steps = steps;
        }
    }
}

