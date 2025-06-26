using JobApplicationTracker.core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.core.Repository
{
    public class BaseRepository<T>: IBaseRepository<T> where T : BaseEntity
    {
        public JobApplicationDbContext _context;
        public async Task<T> AddAsync(T entity)
        {
            entity.Updated = DateTime.Now;
            entity.Created = DateTime.Now;
            await _context.Set<T>().AddAsync(entity);
            var newId = await _context.SaveChangesAsync();
            return await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == newId);
        }
        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<PagedResult<T>> GetListAsync(int pageNumber, int pageSize)
        {
            return await GetListAsync(includeDeleted: false, pageNumber: pageNumber, pageSize: pageSize);
        }

        private async Task<PagedResult<T>> GetListAsync(bool includeDeleted, int pageNumber, int pageSize)
        {
            var query = _context.Set<T>().AsQueryable();

            var totalCount = await query.CountAsync();
            var results = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedResult<T>
            {
                Results = results,
                TotalCount = totalCount,
                PageSize = pageSize,
                PageNumber = pageNumber
            };
        }
    }

    public class PagedResult<T>
    {
        public List<T> Results { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
