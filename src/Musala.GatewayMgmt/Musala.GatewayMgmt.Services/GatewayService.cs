using AutoMapper;
using Musala.GatewayMgmt.Interfaces.DataAccess.Repositories;
using Musala.GatewayMgmt.Model.Dtos.Devices;
using Musala.GatewayMgmt.Model.Dtos.Gateways;
using Musala.GatewayMgmt.Model.Entities;
using Musala.GatewayMgmt.SystemInterfaces.Services;
using Musala.Infrastructure;
using System;
using System.Linq;
using System.Net;
using System.Text;

namespace Musala.GatewayMgmt.Services
{
    public class GatewayService : Service<Gateway, int, GatewayDetailDto>, IGatewayService
    {
        private readonly IGatewayRepository _gatewayRepo;
        private readonly IUnitOfWorkFactory _uowFactory;
        private readonly IMapper _mapper;

        public GatewayService(IGatewayRepository gatewayRepo, IMapper mapper, IUnitOfWorkFactory uowFactory) :
            base(gatewayRepo, mapper, uowFactory)
        {
            _gatewayRepo = gatewayRepo;
            _mapper = mapper;
            _uowFactory = uowFactory;
        }

        public GatewayDetailDto Add(CreateGatewayInput input)
        {
            var entity = Mapper.Map<CreateGatewayInput, Gateway>(input);

            // IPv4 Validation
            var isValidIPAddress = IPAddress.TryParse(input.IPv4, out var ipAddress);

            if (!isValidIPAddress)
                return new GatewayDetailDto
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    StatusMessage = "You must provide a valid IPv4. Ex: 192.168.1.1",
                };

            try
            {
                using (_uowFactory.Create())
                {
                    _gatewayRepo.Add(entity);
                }
            }
            catch (Exception e)
            {
                var dtoWithErrors = Mapper.Map<Gateway, GatewayDetailDto>(entity);
                dtoWithErrors.StatusCode = HttpStatusCode.BadRequest;
                var msg = new StringBuilder();
                msg.AppendLine(e.Message);
                msg.AppendLine(e.InnerException?.Message);
                msg.AppendLine(e.InnerException?.InnerException?.Message);
                dtoWithErrors.StatusMessage = $"Error occurred when processing request: {msg}";

                return dtoWithErrors;
            }

            var dto = Mapper.Map<Gateway, GatewayDetailDto>(entity);
            dto.StatusCode = HttpStatusCode.Created;
            dto.StatusMessage = "Gateway created successfully.";

            return dto;
        }

        public GetGatewaysOutput GetAllWithDeviceInfo()
        {
            var output = new GetGatewaysOutput();

            // Include Device Data
            var gateways = (from g in _gatewayRepo.FindAll(i => i.Devices)
                            select new GatewayDetailDto
                            {
                                SerialNumber = g.SerialNumber,
                                Name = g.Name,
                                Id = g.Id,
                                IPv4 = g.IPv4,
                                Devices = (from d in g.Devices
                                           select new DeviceDetailDto
                                           {
                                               DateCreated = d.DateCreated,
                                               GatewayId = d.GatewayId,
                                               GatewayName = d.Gateway.Name,
                                               Id = d.Id,
                                               Status = d.Status,
                                               UID = d.UID,
                                               Vendor = d.Vendor,
                                           }).ToList(),
                            }).ToList();

            output.Items.AddRange(gateways);

            output.StatusCode = HttpStatusCode.OK;
            output.StatusMessage = "Items retrieved successfully";

            return output;
        }

        public GatewayDetailDto FindByIdWithDeviceInfo(int id)
        {
            var entity = _gatewayRepo.FindById(id, i => i.Devices);

            if (entity == null)
                return new GatewayDetailDto
                {
                    StatusCode = HttpStatusCode.NotFound,
                    StatusMessage = "Gateway not found"
                };

            var dto = Mapper.Map<Gateway, GatewayDetailDto>(entity);
            dto.StatusCode = HttpStatusCode.OK;
            dto.StatusMessage = "Gateway retrieved successfully";
            return dto;
        }
    }
}