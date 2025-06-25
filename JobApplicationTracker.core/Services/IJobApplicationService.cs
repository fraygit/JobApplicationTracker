using JobApplicationTracker.core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobApplicationTracker.core.Services
{
    public interface IJobApplicationService
    {
        Task<JobApplication> AddAsync(JobApplication jobApplication);
        Task UpdateAsync(JobApplication jobApplication);
        Task<List<JobApplication>> ListAllAsync();
        Task<JobApplication> GetAsync(int id);
    }
}
