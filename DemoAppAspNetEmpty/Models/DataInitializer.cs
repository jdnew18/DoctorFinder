using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAppAspNetEmpty.Models
{
    public class DataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PatientContext>
    {
        protected override void Seed(PatientContext context)
        {
            var patients = new List<Patient>
            {
                new Patient{Name="John Doe",Age=40,},
                new Patient{Name="Jane Doe",Age=41,},
                new Patient{Name="Miguel Rodriguez",Age=33,},
                new Patient{Name="Vhana Noor",Age=22,},
                new Patient{Name="Brenda York",Age=76,},
                new Patient{Name="Thomas Brown",Age=46,},
                new Patient{Name="Jalin Johns",Age=34,},
                new Patient{Name="Percy Atwood",Age=17,},
                new Patient{Name="Stuart Montgomery",Age=26,},
                new Patient{Name="Raul Gutierrez",Age=59,},
                new Patient{Name="Rhonda Esteban",Age=52,},
                new Patient{Name="Tracy Atkins",Age=12}
            };

            patients.ForEach(s => context.Patients.Add(s));
            context.SaveChanges();

            var doctors = new List<Doctor>
            {
                new Doctor{Name="Dr. Srini Valasarayan",Age=55,IsAvailableDuringEmergency=true},
                new Doctor{Name="Dr. Keith Smith",Age=29,IsAvailableDuringEmergency=true},
                new Doctor{Name="Dr. Tia Ortiz",Age=71,IsAvailableDuringEmergency=false},
                new Doctor{Name="Dr. Shauna Timkulz",Age=35,IsAvailableDuringEmergency=true},
                new Doctor{Name="Dr. Randall Park",Age=63,IsAvailableDuringEmergency=false},
                new Doctor{Name="Dr. Tian Shu",Age=39,IsAvailableDuringEmergency=true},
                new Doctor{Name="Dr. Noro Nagoke",Age=67,IsAvailableDuringEmergency=true},
            };
            doctors.ForEach(s => context.Doctors.Add(s));
            context.SaveChanges();

            var ailments = new List<Ailment>
            {
                new Ailment{Name="Lupus",},
                new Ailment{Name="Jaundice",},
                new Ailment{Name="Skull Fracture",},
                new Ailment{Name="Arm Fracture",},
                new Ailment{Name="Leg Fracture",},
                new Ailment{Name="Burns",},
                new Ailment{Name="Lung Cancer",},
                new Ailment{Name="Skin Cancer",},
                new Ailment{Name="Liver Cancer",},
                new Ailment{Name="Cardiac Arrest",},
                new Ailment{Name="Pulmonary Embolism",},
                new Ailment{Name="Fever",},
                new Ailment{Name="Seizures",},
                new Ailment{Name="Migraines",},
                new Ailment{Name="Diabetes",},
                new Ailment{Name="Gout"}
            };
            ailments.ForEach(s => context.Ailments.Add(s));
            context.SaveChanges();

            var patientAilmentLookups = new List<PatientAilmentLookup>
            {
                new PatientAilmentLookup{PatientId=1,AilmentId=1},
                new PatientAilmentLookup{PatientId=1,AilmentId=2},
                new PatientAilmentLookup{PatientId=2,AilmentId=3},
                new PatientAilmentLookup{PatientId=2,AilmentId=4},
                new PatientAilmentLookup{PatientId=2,AilmentId=5},
                new PatientAilmentLookup{PatientId=3,AilmentId=6},
                new PatientAilmentLookup{PatientId=4,AilmentId=7},
                new PatientAilmentLookup{PatientId=5,AilmentId=8},
                new PatientAilmentLookup{PatientId=5,AilmentId=9},
                new PatientAilmentLookup{PatientId=6,AilmentId=10},
                new PatientAilmentLookup{PatientId=7,AilmentId=11},
                new PatientAilmentLookup{PatientId=7,AilmentId=12},
                new PatientAilmentLookup{PatientId=7,AilmentId=13},
                new PatientAilmentLookup{PatientId=7,AilmentId=14},
                new PatientAilmentLookup{PatientId=8,AilmentId=15},
                new PatientAilmentLookup{PatientId=9,AilmentId=16},
                new PatientAilmentLookup{PatientId=10,AilmentId=1},
                new PatientAilmentLookup{PatientId=10,AilmentId=10},
                new PatientAilmentLookup{PatientId=11,AilmentId=5},
                new PatientAilmentLookup{PatientId=11,AilmentId=7},
                new PatientAilmentLookup{PatientId=12,AilmentId=16}
            };
            patientAilmentLookups.ForEach(s => context.PatientAilmentLookups.Add(s));
            context.SaveChanges();

            var doctorAilmentLookups = new List<DoctorAilmentLookup>
            {
                new DoctorAilmentLookup{DoctorId=1,AilmentId=1},
                new DoctorAilmentLookup{DoctorId=1,AilmentId=2},
                new DoctorAilmentLookup{DoctorId=2,AilmentId=3},
                new DoctorAilmentLookup{DoctorId=2,AilmentId=4},
                new DoctorAilmentLookup{DoctorId=2,AilmentId=5},
                new DoctorAilmentLookup{DoctorId=3,AilmentId=6},
                new DoctorAilmentLookup{DoctorId=4,AilmentId=7},
                new DoctorAilmentLookup{DoctorId=4,AilmentId=8},
                new DoctorAilmentLookup{DoctorId=4,AilmentId=9},
                new DoctorAilmentLookup{DoctorId=5,AilmentId=10},
                new DoctorAilmentLookup{DoctorId=5,AilmentId=11},
                new DoctorAilmentLookup{DoctorId=1,AilmentId=12},
                new DoctorAilmentLookup{DoctorId=6,AilmentId=13},
                new DoctorAilmentLookup{DoctorId=6,AilmentId=14},
                new DoctorAilmentLookup{DoctorId=7,AilmentId=15},
                new DoctorAilmentLookup{DoctorId=7,AilmentId=16}
            };
            doctorAilmentLookups.ForEach(s => context.DoctorAilmentLookups.Add(s));
            context.SaveChanges();
        }
    }
}