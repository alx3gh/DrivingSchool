using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DrivingSchool.Models
{
    public class AppUser : IdentityUser
    {
        public ICollection<UserLessons> UserLessons { get; set; }
    }
}
