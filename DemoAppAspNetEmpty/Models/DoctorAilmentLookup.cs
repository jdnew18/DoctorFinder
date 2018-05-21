using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DemoAppAspNetEmpty.Models
{
    public class DoctorAilmentLookup
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        [ForeignKey("Ailment")]
        public int AilmentId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Ailment Ailment { get; set; }
    }
}