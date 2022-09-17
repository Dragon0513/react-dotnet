using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserFollowing
    {
        public string ObserverId { get; set; }
        public AppUser Observer { get; set; }

        public string TargetId { get; set; }
        public AppUser Target { get; set; }
    }
}
