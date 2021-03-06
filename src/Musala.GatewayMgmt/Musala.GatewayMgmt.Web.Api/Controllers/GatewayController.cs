﻿using Musala.GatewayMgmt.Model.Dtos.Gateways;
using Musala.GatewayMgmt.SystemInterfaces.Services;
using System;
using System.Web.Http;

namespace Musala.GatewayMgmt.Web.Api.Controllers
{
    [RoutePrefix("api/v1/gateways")]
    public class GatewayController : ApiController
    {
        private IGatewayService _service;

        public GatewayController(IGatewayService service)
        {
            if (service == null)
            {
                var msgError = "Gateway Service exception";
                throw new ArgumentNullException(msgError);
            }

            _service = service;
        }

        // GET api/gateways/
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAllGateways()
        {
            var output = new GetGatewaysOutput();

            try
            {
                output = _service.GetAllWithDeviceInfo();
            }
            catch (Exception e)
            {
                return Ok(new { error = e.Message });
            }

            return Ok(output);
        }

        // GET api/gateways/2
        [Route("{id}")]
        [HttpGet]
        public GatewayDetailDto GetGatewayDetails([FromUri] int id)
        {
            GatewayDetailDto response = new GatewayDetailDto();

            try
            {
                response = _service.FindByIdWithDeviceInfo(id);
            }
            catch (Exception e)
            {
                Helpers.ExceptionHelper.ThrowException(e);
            }

            return response;
        }

        // POST: api/gateways
        [Route("")]
        [HttpPost]
        public IHttpActionResult PostGateway([FromBody] CreateGatewayInput input)
        {
            GatewayDetailDto response = null;

            try
            {
                response = _service.Add(input);
            }
            catch (Exception e)
            {
                Helpers.ExceptionHelper.ThrowException(e);
            }
            return Ok(response);
        }
    }
}
