using Sabio.Web.Domain;
using Sabio.Web.Models.Requests.Properties;
using Sabio.Web.Models.Responses;
using Sabio.Web.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sabio.Web.Controllers.Api
{
    [RoutePrefix("api/properties")]
    public class PropertiesApiController : ApiController
    {
        IPropertiesServices _propertiesService = null;
        public IUserService _userService = null;

        public PropertiesApiController(IPropertiesServices propertiesService, IUserService UserService)
        {
            _propertiesService = propertiesService;
            _userService = UserService;
        }

        [Route, HttpPost]
        public HttpResponseMessage AddProperty(PropertyAddRequest model)
        {
            // if the Model does not pass validation, there will be an Error response returned with errors
            string userId = _userService.GetCurrentUserId();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemResponse<int> response = new ItemResponse<int>();

            response.Item = _propertiesService.Insert(model);

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage PropertiesUpdate(PropertyUpdateRequest model, int id)
        {
            // if the Model does not pass validation, there will be an Error response returned with errors
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            _propertiesService.Update(model);

            SuccessResponse response = new SuccessResponse();

            return Request.CreateResponse(response);
        }

        [Route, HttpGet]
        public HttpResponseMessage GetProperties()
        {
            ItemsResponse<Property> response = new ItemsResponse<Property>();

            response.Items = _propertiesService.GetAll();

            return Request.CreateResponse(response);
        }

        [Route("{id:int}/edit"), HttpGet]
        public HttpResponseMessage GetSelectById(int id)
        {
            ItemResponse<Property> response = new ItemResponse<Property>();

            response.Item = _propertiesService.Get(id);

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("{id:int}/delete"), HttpDelete]
        public HttpResponseMessage DeleteProperty(int id)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemResponse<int> response = new ItemResponse<int>();

            _propertiesService.DeleteById(id);

            return Request.CreateResponse(response);
        }


        [Route("SearchForApn/{search_item}"), HttpGet] //inline constraint defaults to string
        public HttpResponseMessage GetSearchAPN(string search_item)
        {
            ItemsResponse<Property> response = new ItemsResponse<Property>();

            response.Items = _propertiesService.APN_Search(search_item);

            return Request.CreateResponse(response);
        }

        [Route("owner"), HttpGet]                                 //<-- This would get currentuser properties by .GetCurrentUserId()
        public HttpResponseMessage GetPropertiesByOwnerId()
        {
            string userId = _userService.GetCurrentUserId();

            ItemsResponse<Property> response = new ItemsResponse<Property>();

            response.Items = _propertiesService.GetByOwnerId(userId);

            return Request.CreateResponse(response);
        } 

        [Route("owner/{userId:length(6)}"), HttpGet]                                 //<-- This would get users properties by userId 
        public HttpResponseMessage GetPropertiesByUserId(string userId)
        {

            ItemsResponse<Property> response = new ItemsResponse<Property>();

            response.Items = _propertiesService.GetByOwnerId(userId);

            return Request.CreateResponse(response);
        }

        [Route("owner/request"), HttpPost]                                //<-- This is for owners to request 
        public HttpResponseMessage InsertPropertyRequest(PropertyVerificationRequest model)
        {
            string userId = _userService.GetCurrentUserId();

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            SuccessResponse response = new SuccessResponse();

            _propertiesService.PropertyRequestInsert(model, userId);

            return Request.CreateResponse(response);
        }
    }
}

