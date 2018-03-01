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
        //public int ProjectId { get; set; }
        //public virtual Project Project { get; set; } 
        public List<Project> Projects { get; set; }
        public int QUESTORId { get; set; }
        public virtual QUESTOR QUESTOR { get; set; }

        public Module()
        {

        }

        public Module(string title, QUESTOR questor, int moduleId = 0)
        {
            Title = title;
            QUESTOR = questor;
        }
    }
}

