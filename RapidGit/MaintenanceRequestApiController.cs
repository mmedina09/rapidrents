using Rapid.Web.Domain;
using Rapid.Web.Models;
using Rapid.Web.Models.Requests;
using Rapid.Web.Models.Requests.MaintenanceRequest;
using Rapid.Web.Models.Responses;
using Rapid.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sabio.Web.Controllers.Api
{
    [RoutePrefix("api/maintenancerequests")]
    public class MaintenanceRequestApiController : ApiController
    {
        private IMaintenanceRequestServices _service = null;
        public IUserService _userService = null;

        public MaintenanceRequestApiController(IMaintenanceRequestServices service, IUserService UserService)
        {
            _service = service;
            _userService = UserService;
        }

        [Route("add"), HttpPost]
        public HttpResponseMessage Insert(MaintenanceAddRequest model)
        {
            string userId = _userService.GetCurrentUserId();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemResponse<int> response = new ItemResponse<int>();

            response.Item = _service.Insert(model, userId);
            return Request.CreateResponse(response);
        }

        [Route("addressId"), HttpPost]
        public HttpResponseMessage Insert2(MaintenanceAddRequest2 model)
        {
            string userId = _userService.GetCurrentUserId();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemResponse<int> response = new ItemResponse<int>();

            response.Item = _service.Insert2(model, userId);
            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage Update(MaintenanceUpdateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            SuccessResponse response = new SuccessResponse();

            _service.Update(model);

            return Request.CreateResponse(response);
        }

        [Route, HttpGet]
        public HttpResponseMessage Get()
        {
            ItemsResponse<MaintenanceRequest> response = new ItemsResponse<MaintenanceRequest>();

            response.Items = _service.GetAll();

            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            ItemResponse<MaintenanceRequest> response = new ItemResponse<MaintenanceRequest>();

            response.Item = _service.GetId(id);

            return Request.CreateResponse(response);
        }

        [Route("address/{addressId:int}"), HttpGet]
        public HttpResponseMessage GetByAddressId(int addressId)
        {
            ItemsResponse<MaintenanceRequest> response = new ItemsResponse<MaintenanceRequest>();

            response.Items = _service.GetByAddressId(addressId);

            return Request.CreateResponse(response);
        }


        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage DeleteById(int Id)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            _service.Delete(Id);

            SuccessResponse response = new SuccessResponse();

            return Request.CreateResponse(response);
        }
        [Route("{addressid:int}/requests"), HttpGet]
        public HttpResponseMessage GetMaintenanceRqstByAddId(int AddressId)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            ItemResponse<List<MaintenanceRequest>> response = new ItemResponse<List<MaintenanceRequest>>();

            response.Item = _service.GetMaintenanceRqstByAddId(AddressId);

            return Request.CreateResponse(response);
        }

    }
}
