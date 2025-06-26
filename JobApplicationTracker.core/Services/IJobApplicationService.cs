using JobApplicationTracker.core.Entity;
using JobApplicationTracker.core.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobApplicationTracker.core.Services
{
    public interface IJobApplicationService
    {
        Task<JobApplication> AddAsync(JobApplication jobApplication);
        Task<JobApplication> UpdateAsync(int id, JobApplication jobApplication);
        Task<List<JobApplication>> ListAllAsync();
        Task<JobApplication> GetAsync(int id);
        Task<PagedResult<JobApplication>> GetListAsync(int pageNumber, int pageSize);
    }
}
