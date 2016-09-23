using Rapid.Web.Domain;
using Rapid.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rapid.Web.Controllers
{
    [RoutePrefix("maintenancerequests")]
    public class MaintenanceRequestController : BaseController
    {
        [Route("add")]
        [Route("{id:int?}/edit")]        
        public ActionResult Index(int? id = null)
        {
            ItemViewModel<int?> model = new ItemViewModel<int?>();
            model.Item = id;
            return View(model);
        }

        [Route]
        public ActionResult Results()
        {
            return View("ResultsListAngular");
        }

        [Route("address")]
        public ActionResult MaintReq()
        {
            return View("ModalList");
        }
    }
}
