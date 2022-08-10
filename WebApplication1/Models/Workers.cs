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
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public int HouseID { get; set; }
        public House House { get; set; }

    }
}
