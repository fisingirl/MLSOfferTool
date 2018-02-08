using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore.Internal;
using MLSOfferTool.DataAccess;
using MLSOfferTool.Models;

// ReSharper disable once CheckNamespace
namespace MLSOfferTool.Services
{
    public interface IPropertyDataService
    {
        Property GetById(int id);
        IEnumerable<PropertyDto> GetAll();
    }

    public class PropertyDataService : DataServiceBase<MlsOfferToolContext>, IPropertyDataService
    {
        public PropertyDataService()
        {
            using (DataContext)
            {
                this._Entity = DataContext.Properties;
            }
        }

        private IDbSet<Property> _Entity { get; set; }

        public Property GetById(int id)
        {
            return this._Entity.Include("Offer")
                       .SingleOrDefault(x => x.Id == id);

        }

        public IEnumerable<PropertyDto> GetAll()
        {
            var data = this._Entity
                            .Select(x => new PropertyDto()
                               {
                                   Id = x.Id,
                                   Address = x.Address1 + " " + x.Address2,
                                   City = x.City,
                                   ZipCode = x.ZipCode,
                                   Seller = x.PropertySeller.FirstName + " " + x.PropertySeller.LastName
                                })
                           .ToList().OrderBy(x => x.Address);

            return data;
        }
    }
}