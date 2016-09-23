using Rapid.Web.Domain;
using Rapid.Web.Models.Requests.ImportedRents;
using Rapid.Web.Models.Requests.Properties;
using Rapid.Web.Models.Responses;
using Rapid.Web.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Rapid.Web.Controllers.Api
{
    [RoutePrefix("api/imports")]
    public class ImportApiController : ApiController
    {


        I_ImportedProperties _importedPropertiesService = null;
        public IUserService _userService = null;
    

        public ImportApiController(I_ImportedProperties importedPropertiesService, IUserService UserService) {

            _importedPropertiesService = importedPropertiesService;
            _userService = UserService;
        }

        [Route("properties"),HttpPost]
        public  HttpResponseMessage AddImportedProperties(AddImportedProperties model)
        {
            string userId = _userService.GetCurrentUserId();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemResponse<int> response = new ItemResponse<int>();


            response.Item = _importedPropertiesService.ImprotedPropertiesInsert(model);

            return Request.CreateResponse(HttpStatusCode.OK, response);

        }


        [Route("properties/bulk"), HttpPost]
        public HttpResponseMessage AddBulkImportedProperties(AddImportedProperties[] model)
        {
            string userId = _userService.GetCurrentUserId();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemResponse<int> response = new ItemResponse<int>();


            _importedPropertiesService.ImprotedPropertiesBulkInsert(model);

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("properties"), HttpGet]
        public HttpResponseMessage GetImportedProperties()
        {

            ItemsResponse<ImportedProperties> response = new ItemsResponse<ImportedProperties>();


            response.Items = _importedPropertiesService.GetAll_ImportedProperties();

            return Request.CreateResponse(response);
        }

        [Route("rents"), HttpPost]
        public HttpResponseMessage AddImportedRents(AddImportedRents model)
        {
            string userId = _userService.GetCurrentUserId();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemResponse<int> response = new ItemResponse<int>();


            response.Item = _importedPropertiesService.ImportedRentsInsert(model);

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("rents/bulk"), HttpPost]
        public HttpResponseMessage AddBulkImportedRents(AddImportedRents[] model)
        {
            string userId = _userService.GetCurrentUserId();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemResponse<int> response = new ItemResponse<int>();


            _importedPropertiesService.ImportedRentsBulkInsert(model);

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        [Route("rents"), HttpGet]
        public HttpResponseMessage GetImportedRents()
        {

            ItemsResponse<ImportedRents> response = new ItemsResponse<ImportedRents>();


            response.Items = _importedPropertiesService.GetAll_ImportedRents();

            return Request.CreateResponse(response);
        }

        [Route("rents/update"), HttpPost]
        public HttpResponseMessage UpdateAllAddresses()
        {

            ItemResponse<int> response = new ItemResponse<int>();

            _importedPropertiesService.UpdateAllAddresses();

            return Request.CreateResponse(response);

        }

    }
}
