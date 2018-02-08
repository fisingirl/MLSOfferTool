using System.Web.Mvc;
using MLSOfferTool.Services;
using Unity;

namespace MLSOfferTool.Controllers
{
    public class PropertyDataController : Controller
    {
        private IPropertyDataService _PropertyDataService;

        public PropertyDataController(IPropertyDataService propertyDataService)
        {
            this._PropertyDataService = propertyDataService ?? DependencyConfig.Instance.Resolve<IPropertyDataService>();
        }

        // GET: PropertyData
        public ActionResult GetAll()
        {
            var property = this._PropertyDataService.GetAll();
            return Json(property, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProperty(int id)
        {
            var property = this._PropertyDataService.GetById(id);
            return Json(property, JsonRequestBehavior.AllowGet);
        }
    }
}