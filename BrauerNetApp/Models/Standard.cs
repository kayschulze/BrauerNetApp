﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrauerNetApp.Models
{
    [Table("Standards")]
    public class Standard
    {
        [Key]
        public int StandardId { get; set; }
        public string Type { get; set; }
        public string Identifier { get; set; }
        public string Description { get; set; }

        public Standard()
        {

        }

        public Standard(string type, string identifier, string description)
        {
            Type = type;
            Identifier = identifier;
            Description = description;
        }
    }
}
