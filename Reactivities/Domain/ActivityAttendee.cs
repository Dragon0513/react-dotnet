using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ActivityAttendee
    {
        public string AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public Guid ActivityId { get; set; }

        public Activity Activity { get; set; }

        public bool IsHost { get; set; }
    }
}
