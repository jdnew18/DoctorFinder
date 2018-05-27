using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoAppAspNetEmpty.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsAvailableDuringEmergency { get; set; }

        public virtual List<DoctorAilmentLookup> DoctorAilmentLookups { get; set; }
        public virtual List<DoctorRating> DoctorRatings { get; set; }
    }
}