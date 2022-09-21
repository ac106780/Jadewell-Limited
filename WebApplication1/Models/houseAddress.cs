using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class houseAddress
    {
        public int houseAddressID { get; set; }
        [Required]
        public string? Number { get; set; }
        [Required]
        public string? Street { get; set; }
        [Required]
        public string? Suburb { get; set; }
        [Required]
        public string? ZIP { get; set; }
        public int HouseID { get; set; }
        public House? House { get; set; }

    }
}
