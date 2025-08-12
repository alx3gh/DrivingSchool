using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSchool.ViewModels.Track
{
    public class CreateTrackViewModel
    {
        [Required]
        public string Name { get; set; }


        [Required]
        public string Description { get; set; }


        [Required]
        public string Location { get; set; }


        public string? ImageUrl { get; set; }
    }
}
