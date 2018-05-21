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
    public class DoctorService
    {
        public List<DoctorDto> GetAll()
        {
            using (var db = new PatientContext())
            {
                db.Configuration.LazyLoadingEnabled = false;

                try
                {
                    var doctors = new List<DoctorDto>();
                    foreach (var item in db.Doctors.ToList())
                    {
                        doctors.Add(new DoctorDto { Doctor = item });
                    }

                    return doctors;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
        }

        public DoctorDto Get(int id)
        {
            using (var db = new PatientContext())
            {
                db.Configuration.LazyLoadingEnabled = false;

                try
                {
                    var data = db.DoctorAilmentLookups.Where(p => p.DoctorId == id)
                                .Join
                                (
                                    db.Doctors,
                                    _data => _data.DoctorId,
                                    p => p.Id,
                                    (_data, p) => new
                                    {
                                        DoctorAilmentLookup = _data,
                                        Doctor = p
                                    }
                                )
                                .Join
                                (
                                    db.Ailments,
                                    _data => _data.DoctorAilmentLookup.AilmentId,
                                    a => a.Id,
                                    (_data, a) => new
                                    {
                                        DoctorAilmentLookup = _data.DoctorAilmentLookup,
                                        Doctor = _data.Doctor,
                                        Ailment = a
                                    }
                                )
                        .ToList();

                    var doctor = new DoctorDto();
                    doctor.Ailments = new List<Ailment>();
                    doctor.DoctorAilmentLookups = new List<DoctorAilmentLookup>();
                    if (data != null && data.First() != null)
                    {
                        foreach (var item in data)
                        {
                            doctor.Doctor = new Doctor
                            {
                                Id = item.Doctor.Id,
                                Name = item.Doctor.Name,
                                Age = item.Doctor.Age,
                                IsAvailableDuringEmergency = item.Doctor.IsAvailableDuringEmergency
                            };
                            doctor.Ailments.Add(new Ailment
                            {
                                Id = item.Ailment.Id,
                                Name = item.Ailment.Name
                            });
                            doctor.DoctorAilmentLookups.Add(new DoctorAilmentLookup
                            {
                                Id = item.DoctorAilmentLookup.Id,
                                DoctorId = item.DoctorAilmentLookup.DoctorId,
                                AilmentId = item.DoctorAilmentLookup.AilmentId
                            });
                        }
                    }

                    return doctor;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
        }

        public DoctorDto Post(DoctorDto doctor)
        {
            using (var db = new PatientContext())
            {
                using (var transaction = db.Database.BeginTransaction(System.Data.IsolationLevel.Serializable))
                {
                    try
                    {
                        db.Doctors.AddOrUpdate(doctor.Doctor);
                        db.DoctorAilmentLookups.AddOrUpdate(doctor.DoctorAilmentLookups.ToArray());

                        return doctor;
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