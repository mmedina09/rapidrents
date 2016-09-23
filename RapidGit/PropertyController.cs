using Rapid.Web.Models.ViewModels;
using System.Web.Mvc;

namespace Rapid.Web.Controllers
{
    [Authorize]
    [RoutePrefix("properties")]
    public class PropertyController : BaseController
    {
        [Route("add")]
        [Route("{id:int}/edit")]
        public ActionResult PropertyForm(int? id=null)
        {
            ItemViewModel<int?> model = new ItemViewModel<int?>();
            model.Item = id; 
            return View(model);
        }

        [Route("view")]
        public ActionResult PropertyListForm()
        {
            return View("PropertyListFormAngular");
        }

        [Route("dashboard")]
        [Authorize(Roles="Landlord")]
        public ActionResult Dashboard(int? id = null)
        {
            ItemViewModel<int?> model = new ItemViewModel<int?>();
            model.Item = id;
            return View(model);
        }
    }
}
