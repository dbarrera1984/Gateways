using AutoMapper;
using Musala.GatewayMgmt.Interfaces.DataAccess.Repositories;
using Musala.GatewayMgmt.Model.Dtos.Devices;
using Musala.GatewayMgmt.Model.Entities;
using Musala.GatewayMgmt.SystemInterfaces.Services;
using Musala.Infrastructure;
using System.Linq;
using System.Net;

namespace Musala.GatewayMgmt.Services
{
    public class DeviceService : Service<Device, int, DeviceDetailDto>, IDeviceService
    {
        private readonly IDeviceRepository _deviceRepo;
        private readonly IUnitOfWorkFactory _uowFactory;
        private readonly IMapper _mapper;

        public DeviceService(IDeviceRepository deviceRepo, IMapper mapper, IUnitOfWorkFactory uowFactory) :
            base(deviceRepo, mapper, uowFactory)
        {
            _deviceRepo = deviceRepo;
            _mapper = mapper;
            _uowFactory = uowFactory;
        }

        public DeviceDetailDto Add(CreateDeviceInput input)
        {
            var entity = Mapper.Map<CreateDeviceInput, Device>(input);

            // Validation: Each gateway can have up to 10 devices.
            var devicesQty = _deviceRepo.FindAll().Count(w => w.GatewayId == input.GatewayId);
            if (devicesQty >= 10)
            {
                return new DeviceDetailDto
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    StatusMessage = "No more than 10 peripheral devices are allowed for a gateway.",
                };
            }

            using (_uowFactory.Create())
            {
                _deviceRepo.Add(entity);
            }

            var dto = Mapper.Map<Device, DeviceDetailDto>(entity);
            dto.StatusCode = HttpStatusCode.Created;
            dto.StatusMessage = "Device created sucessfully.";

            return dto;
        }

        public GetDevicesOutput GetAllByGateway(int gatewayId)
        {
            var output = new GetDevicesOutput();

            // Filter by Gateway and include Gateway data
            var dtos = (from d in _deviceRepo.FindAll(i => i.Gateway)
                        where d.GatewayId == gatewayId
                        select new DeviceDetailDto
                        {
                            DateCreated = d.DateCreated,
                            GatewayId = d.GatewayId,
                            GatewayName = d.Gateway.Name,
                            Id = d.Id,
                            Status = d.Status,
                            UID = d.UID,
                            Vendor = d.Vendor,
                        }).ToList();

            output.Items.AddRange(dtos);

            return output;
        }

        public GetDevicesOutput GetAllWithGatewayInfo()
        {
            var output = new GetDevicesOutput();

            // Include Gateway Data
            var dtos = (from d in _deviceRepo.FindAll(i=>i.Gateway)
                            select new DeviceDetailDto
                            {
                                DateCreated = d.DateCreated,
                                GatewayId = d.GatewayId,
                                GatewayName = d.Gateway.Name,
                                Id = d.Id,
                                Status = d.Status,
                                UID = d.UID,
                                Vendor = d.Vendor,
                            }).ToList();

            output.Items.AddRange(dtos);

            return output;
        }
    }
}
