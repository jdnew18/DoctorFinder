using DemoAppAspNetEmpty.Models;
using System.Collections.Generic;

namespace DemoAppAspNetEmpty.Dtos
{
    public class DoctorDto
    {
        public Doctor Doctor { get; set; }

        public List<Ailment> Ailments { get; set; }

        public List<DoctorAilmentLookup> DoctorAilmentLookups { get; set; }

        public List<DoctorRating> DoctorRatings { get; set; }
    }
}