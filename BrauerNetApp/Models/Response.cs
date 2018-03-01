using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrauerNetApp.Models
{
    [Table("Responses")]
    public class Response
    {
        [Key]
        public int ResponseId { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public Response() {}

        public Response(string description)
        {
            Description = description;
        }
    }
}

