using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrauerNetApp.Models
{
    [Table("Goals")]
    public class Goal
    {
        [Key]
        public int GoalId { get; set; }
        public string Description { get; set; }

        public virtual List<GoalProject> GoalProjects { get; set; }

        public Goal() {}

        public Goal(string description, int goalId = 0)
        {
            Description = description;
        }
    }
}

