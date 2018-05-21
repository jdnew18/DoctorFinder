using DemoAppAspNetEmpty.Dtos;
using DemoAppAspNetEmpty.Models;
using DemoAppAspNetEmpty.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DemoAppAspNetEmpty.Controllers.API
{
    [RoutePrefix("api/doctor")]
    public class DoctorController : ApiController
    {
        [HttpGet]
        [Route("GetAll")]
        public List<DoctorDto> GetAll()
        {
            return new DoctorService().GetAll();
        }

        [HttpGet]
        [Route("Get")]
        public DoctorDto Get(int id)
        {
            return new DoctorService().Get(id);
        }

        [HttpPost]
        public DoctorDto Post([FromBody] DoctorDto dto)
        {
            return new DoctorService().Post(dto);
        }
    }
}