using JobApplicationTracker.core.Entity;
using JobApplicationTracker.core.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobApplicationTracker.core.Services
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly IJobApplicationRepository _repository;

        public JobApplicationService(IJobApplicationRepository repository)
        {
            _repository = repository;
        }

        public Task<JobApplication> AddAsync(JobApplication jobApplication)
        {
            return _repository.AddAsync(jobApplication);
        }

        public Task<List<JobApplication>> ListAllAsync()
        {
            return _repository.ListAllAsync();
        }

        public Task UpdateAsync(JobApplication jobApplication)
        {
            return _repository.UpdateAsync(jobApplication);
        }

        public Task<JobApplication> GetAsync(int id)
        {
            return _repository.GetAsync(id);
        }

    }
}
