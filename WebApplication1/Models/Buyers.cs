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
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        public string offerPrice { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}



