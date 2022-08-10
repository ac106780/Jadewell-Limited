using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Buyer_House
    {
        public int Buyer_HouseID { get; set; }
        [Required]
        public int HouseID { get; set; }
        public House House { get; set; }
        public int BuyerID { get; set; }
        public Buyers buyers { get; set; }
    }
}

