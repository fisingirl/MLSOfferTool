using System;
using System.Collections.Generic;
using System.Text;

namespace MLSOfferTool.Models
{
    public class Offer : IStampEntity
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public decimal OfferPrice { get; set; }
        public decimal? CounterOfferPrice { get; set; }
        public decimal? AcceptedPrice { get; set; }
        public int OfferStatusId { get; set; }
        public OfferStatus CurrentOfferStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
