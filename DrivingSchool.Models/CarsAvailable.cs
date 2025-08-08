using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSchool.Models
{
    public class CarsAvailable
    {
        public int ActivityId { get; set; }
        [ForeignKey("ActivityId")]
        public Activity Activity { get; set; }

        public int CarsId { get; set; }
        [ForeignKey("CarsId")]
        public Cars Cars { get; set; }
    }
}
