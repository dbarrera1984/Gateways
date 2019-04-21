using Musala.GatewayMgmt.Model.Dtos.Devices;
using Musala.GatewayMgmt.SystemInterfaces.Services;
using System;
using System.Web.Http;

namespace Musala.GatewayMgmt.Web.Api.Controllers
{
    [RoutePrefix("api/devices")]
    public class DeviceController : ApiController
    {
        private IDeviceService _service;

        public DeviceController(IDeviceService service)
        {
            if(service == null)
            {
                var msgError = "Device Service exception";
                throw new ArgumentNullException(msgError);
            }

            _service = service;
        }


        // GET api/devices/
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAllDevices()
        {
            var output = new GetDevicesOutput();

            try
            {
                output = _service.GetAllWithGatewayInfo();
            }
            catch (Exception e)
            {
                return Ok(new { error = e.Message });
            }

            return Ok(output);
        }

        // GET api/devices/1
        [Route("{id}")]
        [HttpGet]
        public DeviceDetailDto GetDeviceDetails([FromUri] int id)
        {
            var response = new DeviceDetailDto();

            try
            {
                response = _service.FindById(id);
            }
            catch (Exception e)
            {
                Helpers.ExceptionHelper.ThrowException(e);
            }

            return response;
        }

        // GET api/devices/gateway/3
        [Route("gateway/{gatewayId}")]
        [HttpGet]
        public GetDevicesOutput GetDevicesByGateway([FromUri] int gatewayId)
        {
            var response = new GetDevicesOutput();

            try
            {
                response = _service.GetAllByGateway(gatewayId);
            }
            catch (Exception e)
            {
                Helpers.ExceptionHelper.ThrowException(e);
            }

            return response;
        }

        // POST: api/devices
        [Route("")]
        [HttpPost]
        public IHttpActionResult PostDevice([FromBody] CreateDeviceInput input)
        {
            DeviceDetailDto response = null;

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
        // DELETE: api/devices/1
        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteDevice([FromUri] int id)
        {
            try
            {
                _service.Remove(id);
            }
            catch (Exception e)
            {
                Helpers.ExceptionHelper.ThrowException(e);
            }
            return Ok("Removed successfully.");
        }
    }
}
