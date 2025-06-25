using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.core.Entity
{
    public class BaseEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Updated { get; set; }
    }
}
