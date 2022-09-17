using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class Profile
    {
        public string Username { get; set; }

        public string DisplayName { get; set; }

        public string Bio { get; set; }

        public string Image { get; set; }


        public bool Following { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingsCount { get; set; }


        public ICollection<Photo> Photos { get; set; }
    }
}
