using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class House
    {
        public int HouseID { get; set; }
        [Required]
        public int buyPrice { get; set; }
        [Required]
        public int sellPrice { get; set; }
        [Required]
        public int dateBought { get; set; }
        [Required]
        public int dateSold { get; set; }       
    }
}
