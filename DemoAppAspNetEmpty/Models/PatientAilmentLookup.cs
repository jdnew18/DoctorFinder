using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAppAspNetEmpty.Models
{
    public class PatientAilmentLookup
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        [ForeignKey("Ailment")]
        public int AilmentId { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Ailment Ailment { get; set; }
    }
}