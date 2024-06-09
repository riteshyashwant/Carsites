using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionService.DTOs
{
    public class AuctionDto
    {
         public Guid ID  { get; set; }
        public int ReversePrice { get; set; }
        public string Seller { get; set; }
          public string Winner { get; set; }

             public int? CurrentHighBid { get; set; }

             
         public DateTime? CreatedDate  { get; set; } 
         public DateTime? UpdatedDate  { get; set; } 
         public DateTime? AuctionEnd  { get; set; }

         public string Status  { get; set; } 
          public string Make { get; set; }
         public string Model { get; set; }
         public int Year { get; set; }
         public string Color { get; set; }
         public int Milage  { get; set; } =0;
         public string ImageUrl { get; set; }
        
    }
}