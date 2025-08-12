using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingSchool.Models;

namespace DrivingSchool.ViewModels.CarsVM
{
    public class CurrentCarsViewModel
    {
        public int ActivityId { get; set; }

        public string ActivityName { get; set; }

        public List<Cars> Cars { get; set; }

        public List<int> SelectedCars { get; set; }

        //public List<Cars> AllCars { get; set; } = string.Empty;


        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
