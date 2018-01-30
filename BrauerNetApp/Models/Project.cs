using System;
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

        public Project()
        {

        }

        public Project(string name, int projectId = 0)
        {
            Name = name;
        }
    }
}

