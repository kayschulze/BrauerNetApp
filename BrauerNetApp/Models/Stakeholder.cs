using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrauerNetApp.Models
{
    [Table("Stakeholders")]
    public class Stakeholder
    {
        [Key]
        public int StakeholderId { get; set; }
        public string Organization { get; set; }
        public string ContactName { get; set; }
        public string Notes { get; set; }

        public Stakeholder()
        {

        }

        public Stakeholder(string organization, string contactName, string notes)
        {
            Organization = organization;
            ContactName = contactName;
            Notes = notes;
        }
    }
}

