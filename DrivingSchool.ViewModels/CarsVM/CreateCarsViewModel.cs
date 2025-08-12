using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSchool.ViewModels.CarsVM
{
    public class CreateCarsViewModel
    {

        public int ActivityId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }


        public string? ImageUrl { get; set; }
    }
}
