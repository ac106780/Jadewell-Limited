using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Workers
    {
        public int WorkersID { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public int HouseID { get; set; }
        public House? House { get; set; }

    }
}
