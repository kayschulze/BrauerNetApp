using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrauerNetApp.Models
{
    [Table("Projects")]
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public virtual Module Module { get; set; }
        public int ModuleId { get; set; }

        public virtual List<ProjectStandard> ProjectStandards { get; set; }

        public virtual List<Step> Steps { get; set; }
        public virtual List<Response> Responses { get; set; }

        [NotMapped]
        public virtual List<Standard> Standards { get; set; }

        public Project() { }

        public Project(string name, int projectId = 0)
        {
            Name = name;
        }
    }
}

