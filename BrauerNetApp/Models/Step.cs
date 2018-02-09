using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrauerNetApp.Models
{
    [Table("Steps")]
    public class Step
    {
        [Key]
        public int StepId { get; set; }
        public string Description { get; set; }

        public Step()
        {

        }

        public Step(string description, int stepId = 0)
        {
            Description = description;
        }
    }
}

