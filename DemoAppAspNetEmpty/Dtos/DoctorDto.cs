using DemoAppAspNetEmpty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAppAspNetEmpty.Dtos
{
    public class DoctorDto
    {
        public Doctor Doctor { get; set; }

        public List<Ailment> Ailments { get; set; }

        public List<DoctorAilmentLookup> DoctorAilmentLookups { get; set; }
    }
}