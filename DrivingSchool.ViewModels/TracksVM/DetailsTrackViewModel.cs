using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingSchool.ViewModels.ActivityVM;
using DrivingSchool.ViewModels.DriversVM;


namespace DrivingSchool.ViewModels.TracksVM
{
    public class DetailsTrackViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public List<ActivityViewModel> Activity { get; set; } = new List<ActivityViewModel>();
        public List<DriversViewModel> Drivers { get; set; } = new List<DriversViewModel>();
    }
}
