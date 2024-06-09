using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionService.Entities
{
    [Table("Items")]
    public class Item
    {
         public Guid ID  { get; set; }
         public string Make { get; set; }
         public string Model { get; set; }
         public int Year { get; set; }
         public string Color { get; set; }
         public int Milage  { get; set; } =0;
         public string ImageUrl { get; set; }
         public int? SoldAmount { get; set; }

//nav property
         public Auction Auction { get; set; }
         public Guid AuctionId { get; set; }

    }
}