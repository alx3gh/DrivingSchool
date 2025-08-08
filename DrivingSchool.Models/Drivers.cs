using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSchool.Models
{
    public class Drivers
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Age { get; set; }

        [Required]
        public string Bio { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public int TrackId { get; set; }

        [ForeignKey("TrackId")]
        public Track Track { get; set; }

        public ICollection<Lessons> Lessons { get; set; } = new List<Lessons>();
    }
}
