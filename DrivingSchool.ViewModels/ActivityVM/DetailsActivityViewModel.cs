using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingSchool.Models;

namespace DrivingSchool.ViewModels.ActivityVM
{
    public class DetailsActivityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Track Track { get; set; }
        public List<CarsAvailableViewModel> CarsAvailable { get; set; }
    }
}
