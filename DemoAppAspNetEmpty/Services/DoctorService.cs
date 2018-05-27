using DemoAppAspNetEmpty.Dtos;
using DemoAppAspNetEmpty.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAppAspNetEmpty.Services
{
    public class DoctorService
    {
        public async Task<List<DoctorDto>> GetAll()
        {
            using (var db = new PatientContext())
            {
                db.Configuration.LazyLoadingEnabled = false;

                try
                {
                    var doctors = new List<DoctorDto>();
                    foreach (var item in await db.Doctors.ToListAsync())
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

        public async Task<DoctorDto> Get(int id)
        {
            using (var db = new PatientContext())
            {
                db.Configuration.LazyLoadingEnabled = false;

                try
                {
                    var data = await db.DoctorAilmentLookups.Where(p => p.DoctorId == id)
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
                                .GroupJoin
                                (
                                    db.DoctorRatings,
                                    _data => _data.DoctorAilmentLookup.DoctorId,
                                    d => d.DoctorId,
                                    (_data, d) => new
                                    {
                                        DoctorAilmentLookup = _data.DoctorAilmentLookup,
                                        Doctor = _data.Doctor,
                                        Ailment = _data.Ailment,
                                        DoctorRating = d.DefaultIfEmpty()
                                    }
                                )
                        .ToListAsync();

                    var doctor = new DoctorDto();
                    doctor.Ailments = new List<Ailment>();
                    doctor.DoctorAilmentLookups = new List<DoctorAilmentLookup>();
                    doctor.DoctorRatings = new List<DoctorRating>();
                    if (data != null && data.First() != null)
                    {
                        doctor.Doctor = new Doctor
                        {
                            Id = data.First().Doctor.Id,
                            Name = data.First().Doctor.Name,
                            Age = data.First().Doctor.Age,
                            IsAvailableDuringEmergency = data.First().Doctor.IsAvailableDuringEmergency
                        };

                        if (data.First().DoctorRating != null && data.First().DoctorRating.First() != null)
                        {
                            doctor.DoctorRatings = data.First().DoctorRating.ToList();
                        }

                        foreach (var item in data)
                        {
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

        public async Task<DoctorDto> Post(DoctorDto doctor)
        {
            using (var db = new PatientContext())
            {
                using (var transaction = db.Database.BeginTransaction(System.Data.IsolationLevel.Serializable))
                {
                    try
                    {
                        db.Doctors.AddOrUpdate(doctor.Doctor);
                        db.DoctorAilmentLookups.AddOrUpdate(doctor.DoctorAilmentLookups.ToArray());

                        await db.SaveChangesAsync();
                        transaction.Commit();

                        return doctor;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine(ex);
                        throw;
                    }
                }
            }
        }
    }
}