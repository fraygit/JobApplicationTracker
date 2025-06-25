using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add in-memory database
builder.Services.AddDbContext<JobApplicationTracker.core.JobApplicationDbContext>(options =>
    options.UseInMemoryDatabase("JobApplicationDb"));

// Dependency Injection
builder.Services.AddScoped<JobApplicationTracker.core.Repository.IJobApplicationRepository, JobApplicationTracker.core.Repository.JobApplicationRepository>();
builder.Services.AddScoped<JobApplicationTracker.core.Services.IJobApplicationService, JobApplicationTracker.core.Services.JobApplicationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
