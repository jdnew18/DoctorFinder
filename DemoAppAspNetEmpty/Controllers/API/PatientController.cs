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
    [RoutePrefix("api/patient")]
    public class PatientController : ApiController
    {
        [HttpGet]
        [Route("GetAll")]
        public List<PatientDto> GetAll()
        {
            return new PatientService().GetAll();
        }

        [HttpGet]
        [Route("Get")]
        public PatientDto Get(int id)
        {
            return new PatientService().Get(id);
        }

        [HttpPost]
        public PatientDto Post([FromBody] PatientDto dto)
        {
            return new PatientService().Post(dto);
        }
    }
}