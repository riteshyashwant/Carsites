using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionService.Entities
{
    public class Auction
    {
        public Guid ID  { get; set; }
        public int ReversePrice { get; set; } =0;
        public string Seller { get; set; }
          public string Winner { get; set; }

             public int? CurrentHighBid { get; set; }

             
         public DateTime? CreatedDate  { get; set; } = DateTime.UtcNow ;
         public DateTime? UpdatedDate  { get; set; } = DateTime.UtcNow ;
         public DateTime? AuctionEnd  { get; set; }

         public Status Status  { get; set; } 
         public Item Item  { get; set; } 


    }
}