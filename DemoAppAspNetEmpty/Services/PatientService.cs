using DemoAppAspNetEmpty.Dtos;
using DemoAppAspNetEmpty.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace DemoAppAspNetEmpty.Services
{
    public class PatientService
    {
        public List<PatientDto> GetAll()
        {
            using (var db = new PatientContext())
            {
                db.Configuration.LazyLoadingEnabled = false;

                try
                {
                    var patients = new List<PatientDto>();
                    foreach (var item in db.Patients.ToList())
                    {
                        patients.Add(new PatientDto { Patient = item });
                    }

                    return patients;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
        }

        public PatientDto Get(int id)
        {
            using (var db = new PatientContext())
            {
                db.Configuration.LazyLoadingEnabled = false;

                try
                {
                    var data = db.PatientAilmentLookups.Where(p => p.PatientId == id)
                                .Join
                                (
                                    db.Patients,
                                    _data => _data.PatientId,
                                    p => p.Id,
                                    (_data, p) => new
                                    {
                                        PatientAilmentLookup = _data,
                                        Patient = p
                                    }
                                )
                                .Join
                                (
                                    db.Ailments,
                                    _data => _data.PatientAilmentLookup.AilmentId,
                                    a => a.Id,
                                    (_data, a) => new
                                    {
                                        PatientAilmentLookup = _data.PatientAilmentLookup,
                                        Patient = _data.Patient,
                                        Ailment = a
                                    }
                                )
                        .ToList();

                    var patient = new PatientDto();
                    patient.Ailments = new List<Ailment>();
                    patient.PatientAilmentLookups = new List<PatientAilmentLookup>();
                    if (data != null && data.First() != null)
                    {
                        foreach (var item in data)
                        {
                            patient.Patient = new Patient{
                                Id = item.Patient.Id,
                                Name = item.Patient.Name,
                                Age = item.Patient.Age
                            };
                            patient.Ailments.Add(new Ailment
                            {
                                Id = item.Ailment.Id,
                                Name = item.Ailment.Name
                            });
                            patient.PatientAilmentLookups.Add(new PatientAilmentLookup
                            {
                                Id = item.PatientAilmentLookup.Id,
                                PatientId = item.PatientAilmentLookup.PatientId,
                                AilmentId = item.PatientAilmentLookup.AilmentId
                            });
                        }
                    }

                    return patient;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
        }

        public PatientDto Post(PatientDto patient)
        {
            using (var db = new PatientContext())
            {
                using (var transaction = db.Database.BeginTransaction(System.Data.IsolationLevel.Serializable))
                {
                    try
                    {
                        db.Patients.AddOrUpdate(patient.Patient);
                        db.PatientAilmentLookups.AddOrUpdate(patient.PatientAilmentLookups.ToArray());

                        return patient;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        throw;
                    }
                }
            }
        }
    }
}