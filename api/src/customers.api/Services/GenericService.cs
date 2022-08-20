using Customers.Data.Interface;
using System.Collections.Generic;
using AutoMapper;

namespace Customers.Api.Services.Interface
{
    public class GenericService<TModel, TDto> : IGenericService<TModel, TDto>
        where TDto : class
        where TModel : class
    {
        protected readonly IGenericRepository<TDto> _repository;
        protected readonly IMapper _mapper;

        public GenericService(IMapper mapper, IGenericRepository<TDto> repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<TModel> GetAll()
        {
            var entities = _repository.GetAll();
            return _mapper.Map<IEnumerable<TDto>, IEnumerable<TModel>>(entities);
        }

        public TModel Get(int id)
        {
            var entity = _repository.Get(id);
            return _mapper.Map<TDto, TModel>(entity);
        }

        public void Update(TModel entity)
        {
            var dto = _mapper.Map<TModel, TDto>(entity);
            _repository.Update(dto);
        }
    }
}
