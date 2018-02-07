using System;
using System.Collections.Generic;
using System.Text;

namespace MLSOfferTool.Models
{
    public class Buyer : IStampEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
