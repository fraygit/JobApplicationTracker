

using JobApplicationTracker.core.Entity;
using JobApplicationTracker.core.Repository;
using JobApplicationTracker.core.Services;
using Moq;

namespace JobApplicationTracker.test
{
    public class JobApplicationServiceTests
    {
        private readonly Mock<IJobApplicationRepository> _mockRepo;
        private readonly JobApplicationService _service;

        public JobApplicationServiceTests()
        {
            _mockRepo = new Mock<IJobApplicationRepository>();
            _service = new JobApplicationService(_mockRepo.Object);
        }

        [Fact]
        public async Task TestAddJobApplication()
        {
            var jobApp = new JobApplication { Id = 1, Company = "Acme", Position = "Dev", Status = ApplicationStatus.Applied, ApplicationDate = DateTime.UtcNow };
            _mockRepo.Setup(r => r.AddAsync(jobApp)).ReturnsAsync(jobApp);
            var result = await _service.AddAsync(jobApp);
            Assert.Equal(jobApp, result);
            _mockRepo.Verify(r => r.AddAsync(jobApp), Times.Once);
        }

        [Fact]
        public async Task TestListAllAsync()
        {
            var jobApps = new List<JobApplication> {
                new JobApplication { Id = 1, Company = "Acme", Position = "Manager", Status = ApplicationStatus.Applied, ApplicationDate = DateTime.UtcNow },
                new JobApplication { Id = 2, Company = "Star", Position = "Janitor", Status = ApplicationStatus.Interviewed, ApplicationDate = DateTime.UtcNow }
            };
            _mockRepo.Setup(r => r.ListAllAsync()).ReturnsAsync(jobApps);
            var result = await _service.ListAllAsync();
            Assert.Equal(jobApps, result);
            _mockRepo.Verify(r => r.ListAllAsync(), Times.Once);
        }

        [Fact]
        public async Task TestUpdateAsync()
        {
            var jobApp = new JobApplication { Id = 1, Company = "TestCo", Position = "Dev", Status = ApplicationStatus.Offered, ApplicationDate = DateTime.UtcNow };
            _mockRepo.Setup(r => r.UpdateAsync(jobApp)).Returns(Task.CompletedTask);
            await _service.UpdateAsync(jobApp);
            _mockRepo.Verify(r => r.UpdateAsync(jobApp), Times.Once);
        }

        [Fact]
        public async Task TestGetAsync()
        {
            var jobApp = new JobApplication { Id = 1, Company = "Acme", Position = "Dev", Status = ApplicationStatus.Applied, ApplicationDate = DateTime.UtcNow };
            _mockRepo.Setup(r => r.GetAsync(1)).ReturnsAsync(jobApp);
            var result = await _service.GetAsync(1);
            Assert.Equal(jobApp, result);
            _mockRepo.Verify(r => r.GetAsync(1), Times.Once);
        }
    }
}