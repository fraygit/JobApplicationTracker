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
    }
}
