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
            if (jobApplication == null)
                throw new ArgumentNullException(nameof(jobApplication));
            if (string.IsNullOrWhiteSpace(jobApplication.Company))
                throw new ArgumentException("Company must be provided.", nameof(jobApplication.Company));
            if (string.IsNullOrWhiteSpace(jobApplication.Position))
                throw new ArgumentException("Position must be provided.", nameof(jobApplication.Position));
            if (jobApplication.ApplicationDate == default(DateTime))
                throw new ArgumentException("ApplicationDate must be a valid date.", nameof(jobApplication.ApplicationDate));

            return _repository.AddAsync(jobApplication);
        }

        public Task<List<JobApplication>> ListAllAsync()
        {
            return _repository.ListAllAsync();
        }

        public async Task<JobApplication> UpdateAsync(int id, JobApplication jobApplication)
        {
            var application = await _repository.GetAsync(id);
            application.Status = jobApplication.Status;
            application.Updated = DateTime.Now;
            await _repository.UpdateAsync(application);
            return application;
        }

        public Task<JobApplication> GetAsync(int id)
        {
            return _repository.GetAsync(id);
        }

        public Task<PagedResult<JobApplication>> GetListAsync(int pageNumber, int pageSize)
        {
            return _repository.GetListAsync(pageNumber, pageSize);
        }
    }
}
