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
        [Display(Name = "Buy Price")]
        public string? BuyPrice { get; set; }
        [Display(Name = "Sell Price")]
        public string? SellPrice { get; set; }
        [Required]
        [Display(Name = "Date Bought")]
        public string? DateBought { get; set; }
        [Display(Name = "Date Sold")]
        public string? DateSold { get; set; }       
    }
}
