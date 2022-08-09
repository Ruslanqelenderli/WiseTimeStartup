using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseTime.Entity.Entities.Manage
{
    public class User:IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname  { get; set; }
        public string SchoolName { get; set; }
        public string UniversityName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Gender { get; set; }
        public string Fin { get; set; }
        public string Image { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
