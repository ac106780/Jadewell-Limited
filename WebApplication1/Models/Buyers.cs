using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Buyers
    {
        public int BuyerID { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        public int offerPrice { get; set; }
        [Required]
        public int Phone { get; set; }
        public int Email { get; set; }
    }
}

