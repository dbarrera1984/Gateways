using AutoMapper;
using Musala.GatewayMgmt.Model.Dtos;
using Musala.GatewayMgmt.SystemInterfaces.Services;
using Musala.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Musala.GatewayMgmt.Services
{
    public class Service<T, K, TDto> : IService<TDto, K>
        where T : MusalaEntity<K>
        where TDto : ItemDto<K>
    {
        private readonly IRepository<T, K> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkFactory _uowFactory;
        public Service(IRepository<T, K> repository, IMapper mapper, IUnitOfWorkFactory uowFactory)
        {
            _repository = repository;
            _mapper = mapper;
            _uowFactory = uowFactory;
        }


        public TDto FindById(K id)
        {
            var entity = _repository.FindById(id);

            return Mapper.Map<T, TDto>(entity);
        }

        public GetItemDtosOutput<TDto, K> GetAll()
        {
            var output = new GetItemDtosOutput<TDto, K>();

            var entities = _repository.FindAll();
            var dtos = Mapper.Map<IEnumerable<T>, IEnumerable<TDto>>(entities);

            output.Items.AddRange(dtos);

            return output;
        }

        public void Remove(K id)
        {
            using (_uowFactory.Create())
            {
                _repository.Remove(id);
            }
        }      
    }
}
