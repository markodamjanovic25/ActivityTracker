using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLibrary.Models
{
    public class ActivityOption
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Flag { get; set; }
        public string Description { get; set; }
    }
}
