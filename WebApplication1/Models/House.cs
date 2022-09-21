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
        public string? BuyPrice { get; set; }
        [Required]
        public string? SellPrice { get; set; }
        [Required]
        public string? DateBought { get; set; }
        [Required]
        public string? DateSold { get; set; }       
    }
}
