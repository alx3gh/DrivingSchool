using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSchool.ViewModels.ActivityVM
{
    public class CreateActivityViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string? ImageUrl { get; set; }


        public int TrackId { get; set; }
    }
}
