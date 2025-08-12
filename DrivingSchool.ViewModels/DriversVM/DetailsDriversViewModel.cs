using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingSchool.Models;

namespace DrivingSchool.ViewModels.DriversVM
{
    public class DetailsDriversViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Bio { get; set; }
        public string ImageUrl { get; set; }
        public Track Track { get; set; }
        public List<Lessons> Lessons { get; set; }

    }
}
