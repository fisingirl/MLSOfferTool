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
        Property GetPropertyById(int id);
    }

    public class PropertyDataService : DataServiceBase<MlsOfferToolContext>, IPropertyDataService
    {
        public PropertyDataService()
        {
            using (DataContext)
            {
                this._Entity = DataContext.Properties;
            }

            //this._Context = context;
            //this._Entity = context.Properties;
        }

        //private IMlsOfferToolContext _Context { get; set; }
        private IDbSet<Property> _Entity { get; set; }

        public Property GetPropertyById(int id)
        {
            //return this._Context.Properties
            //                    .Include("Offer")
            //                    .SingleOrDefault(x => x.Id == id);

            return this._Entity.Include("Offer")
                       .SingleOrDefault(x => x.Id == id);

        }
    }
}