using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MLSOfferTool.Services;

namespace MLSOfferTool.Controllers
{
    public class PropertyDataController : Controller
    {
        private IPropertyDataService _PropertyDataService;

        public PropertyDataController() : this(null)
        {  
        }

        public PropertyDataController(IPropertyDataService propertyDataService)
        {
            this._PropertyDataService = propertyDataService;
        }

        // GET: PropertyData
        public ActionResult GetAll()
        {
            return null;
        }
        public ActionResult GetProperty(int id)
        {
            return null;
        }
    }
}