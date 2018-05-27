using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoAppAspNetEmpty.Models
{
    public class Ailment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<PatientAilmentLookup> PatientAilmentLookups { get; set; }
        public virtual List<DoctorAilmentLookup> DoctorAilmentLookups { get; set; }
    }
}