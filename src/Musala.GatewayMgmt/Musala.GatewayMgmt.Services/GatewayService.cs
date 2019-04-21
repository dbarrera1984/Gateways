using AutoMapper;
using Musala.GatewayMgmt.Interfaces.DataAccess.Repositories;
using Musala.GatewayMgmt.Model.Dtos.Gateways;
using Musala.GatewayMgmt.Model.Entities;
using Musala.GatewayMgmt.SystemInterfaces.Services;
using Musala.Infrastructure;
using System.Net;

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

            using (_uowFactory.Create())
            {
                _gatewayRepo.Add(entity);
            }

            var dto = Mapper.Map<Gateway, GatewayDetailDto>(entity);
            dto.StatusCode = HttpStatusCode.Created;
            dto.StatusMessage = "Gateway created sucessfully.";

            return dto;
        }
    }
}
