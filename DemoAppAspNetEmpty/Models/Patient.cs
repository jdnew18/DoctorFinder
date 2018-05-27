using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoAppAspNetEmpty.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public virtual List<PatientAilmentLookup> PatientAilmentLookups { get; set; }
    }
}