using DemoAppAspNetEmpty.Models;
using System.Collections.Generic;

namespace DemoAppAspNetEmpty.Dtos
{
    public class PatientDto
    {
        public Patient Patient { get; set; }

        public List<Ailment> Ailments { get; set; }

        public List<PatientAilmentLookup> PatientAilmentLookups { get; set; }
    }
}