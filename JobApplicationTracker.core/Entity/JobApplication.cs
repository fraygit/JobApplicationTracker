using System;

namespace JobApplicationTracker.core.Entity
{
    public enum ApplicationStatus
    {
        Applied,
        Interviewed,
        Offered,
        Rejected
    }

    public class JobApplication : BaseEntity
    {
        public string Company { get; set; }
        public string Position { get; set; }
        public ApplicationStatus Status { get; set; }
        public DateTime ApplicationDate { get; set; }
    }
}
