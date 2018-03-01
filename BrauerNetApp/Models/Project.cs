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
        
        //public virtual List<Module> Modules { get; set; }
        public virtual List<Step> Steps { get; set; }
        public virtual List<Response> Responses { get; set; }
        public virtual List<Standard> Standards { get; set; }

        public Project()
        {

        }

        public Project(string name, int projectId = 0)
        {
            Name = name;
        }
    }
}

