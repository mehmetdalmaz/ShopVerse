using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopVerse.DataAccess.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task<T> TGetByIdAsync(Guid id);
        Task<List<T>> TGetAllAsync();
        Task TAddAsync(T entity);
        Task TUpdateAsync(T entity);
        Task TDeleteAsync(Guid id);
    }
   
}