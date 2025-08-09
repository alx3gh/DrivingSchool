using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingSchool.Models;

namespace DrivingSchool.ViewModels.ActivityViewModel
{
    public class ActivityViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? ImageUrl { get; set; }
    }
}
