using DemoAppAspNetEmpty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAppAspNetEmpty.Dtos
{
    public class PatientDto
    {
        public Patient Patient { get; set; }

        public List<Ailment> Ailments { get; set; }

        public List<PatientAilmentLookup> PatientAilmentLookups { get; set; }
    }
}