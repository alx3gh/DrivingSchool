using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSchool.Models
{
    public class UserLessons
    {
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public AppUser User { get; set; }

        public int LessonsId { get; set; }
        [ForeignKey("LessonsId")]
        public Lessons Lessons { get; set; }
    }
}
