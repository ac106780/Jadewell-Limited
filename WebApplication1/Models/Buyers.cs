using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Buyers
    {
        public int BuyersID { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public string? OfferPrice { get; set; }
        [Required]
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}



