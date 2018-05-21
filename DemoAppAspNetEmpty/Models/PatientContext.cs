using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemoAppAspNetEmpty.Models
{
    public class PatientContext : DbContext
    {
        public PatientContext() : base("PatientContext") { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Ailment> Ailments { get; set; }
        public DbSet<PatientAilmentLookup> PatientAilmentLookups { get; set; }
        public DbSet<DoctorAilmentLookup> DoctorAilmentLookups { get; set; }
    }
}