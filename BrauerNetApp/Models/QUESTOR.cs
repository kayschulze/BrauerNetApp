using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrauerNetApp.Models
{
    [Table("QUESTORs")]
    public class QUESTOR
    {
        [Key]
        public int QUESTORId { get; set; }
        public string Question { get; set; }
        public virtual List<Goal> Goals { get; set; }
        public virtual List<Module> Modules { get; set; }
        public virtual List<Stakeholder> Stakeholders { get; set; }

        public QUESTOR() {}

        public QUESTOR(string question, List<Goal> goals, List<Module> modules, List<Stakeholder> stakeholders)
        {
            Question = question;
            Goals = goals;
            Modules = modules;
            Stakeholders = stakeholders;
        }
    }
}

