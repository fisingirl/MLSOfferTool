using System;
using System.Collections.Generic;
using System.Text;

namespace MLSOfferTool.Models
{
    public class Property : IStampEntity
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string CompanyName { get; set; }
        public int SellerId { get; set; }
        public Seller PropertySeller { get; set; }
        public int? BuyerId { get; set; }
        public decimal PropertyValue { get; set; }
        public decimal RepairEstimate { get; set; }
        public Buyer PropertyBuyer { get; set; }
        public int FirstOfferId { get; set; }
        public Offer FirstOffer { get; set; }
        public int? SecondOfferId { get; set; }
        public Offer SecondOffer { get; set; }
        public int? ThirdOfferId { get; set; }
        public Offer ThirdOffer { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
