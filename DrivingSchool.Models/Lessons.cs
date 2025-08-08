using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSchool.Models
{
    public class Lessons
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int Price { get; set; }

        public int DriversId { get; set; }

        [ForeignKey("DriversId")]
        public Drivers Drivers { get; set; } = null!;
    }
}
