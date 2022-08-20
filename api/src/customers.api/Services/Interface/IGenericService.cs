using System.Collections.Generic;

namespace Customers.Api.Services.Interface
{
    public interface IGenericService<TModel, TDto>
        where TModel : class
        where TDto : class
    {
        IEnumerable<TModel> GetAll();
        TModel Get(int id);
        void Update(TModel entity);
    }
}
