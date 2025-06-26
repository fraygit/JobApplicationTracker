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

        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize)
        {
            var applications = await _jobApplicationService.GetListAsync(pageNumber, pageSize);
            return Ok(applications);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] JobApplication jobApplication)
        {
            var created = await _jobApplicationService.AddAsync(jobApplication);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] JobApplication jobApplication)
        {
            await _jobApplicationService.UpdateAsync(id, jobApplication);
            return CreatedAtAction(nameof(GetById), new { id = jobApplication.Id }, jobApplication);
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
