using Microsoft.AspNetCore.Mvc;
using JobApplicationTracker.core.Services;
using JobApplicationTracker.core.Entity;

namespace JobApplicationTracker.API.Controllers
{
    [ApiController]
    [Route("api/applications")]
    public class JobApplicationController : ControllerBase
    {
        private readonly IJobApplicationService _jobApplicationService;

        public JobApplicationController(IJobApplicationService jobApplicationService)
        {
            _jobApplicationService = jobApplicationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var applications = await _jobApplicationService.ListAllAsync();
            return Ok(applications);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] JobApplication jobApplication)
        {
            var created = await _jobApplicationService.AddAsync(jobApplication);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var application = await _jobApplicationService.GetAsync(id);
            if (application == null)
                return NotFound();
            return Ok(application);
        }
    }
}
