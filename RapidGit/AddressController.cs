using Sabio.Web.Models.ViewModels;
using System.Web.Mvc;

namespace Sabio.Web.Controllers
{
    [Authorize]
    [RoutePrefix("addresses")]
    public class AddressController : BaseController
    {
        [Route("add")]
        [Route("{id:int}/edit")]
        public ActionResult ViewAddress(int? id = null)
        {
            ItemViewModel<int?> model = GetViewModel<ItemViewModel<int?>>();

            model.Item = id;

            return View("AddAddressAngular", model);
        }

        [Route("geography")]
        public ActionResult Geography()
        {
            return View();
        }

        [Route("byApn")]
        public ActionResult ByApn()
        {

            return View("AddressByApn");
        }
        ////Test Page
       
        public ActionResult AddressTest()
        {
            return View();
        }

        [Route("rentcheck")]
        public ActionResult RentCheck()
        {

            return View();
        }
    }
}
