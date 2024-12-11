using OriontekClientsServer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OriontekClientsServer.Domain.Repositories
{

    public interface IRepository<T> where T : CoreEntity
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllPaginatedAsync(int page, int limit);
        Task<int> CountAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
    }
}
