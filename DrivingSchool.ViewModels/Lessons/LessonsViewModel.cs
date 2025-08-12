﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSchool.ViewModels.Lessons
{
    public class LessonsViewModel
    {
        [Required]

        public string Name { get; set; }

        [Required]

        public int Price { get; set; }

        [Required]

        public string Description { get; set; }

        public int DriversId { get; set; }
    }
}
