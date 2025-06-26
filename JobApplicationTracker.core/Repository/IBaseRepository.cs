using JobApplicationTracker.core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.core.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<List<T>> ListAllAsync();
        Task<T> GetAsync(int id);
        Task<PagedResult<T>> GetListAsync(int pageNumber, int pageSize);
    }
}
