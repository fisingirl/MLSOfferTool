using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MLSOfferTool.Models
{
    public interface IStampEntity
    {
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
    }

    public abstract class StampEntity : IStampEntity
    {
        [Display(Name = "Created by")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Updated by")]
        public DateTime UpdatedDate { get; set; }
    }
}
