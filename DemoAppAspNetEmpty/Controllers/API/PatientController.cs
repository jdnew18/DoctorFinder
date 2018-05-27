using DemoAppAspNetEmpty.Dtos;
using DemoAppAspNetEmpty.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace DemoAppAspNetEmpty.Controllers.API
{
    [RoutePrefix("api/patient")]
    public class PatientController : ApiController
    {
        [HttpGet]
        [Route("GetAll")]
        public async Task<List<PatientDto>> GetAll()
        {
            return await new PatientService().GetAll();
        }

        [HttpGet]
        [Route("Get")]
        public async Task<PatientDto> Get(int id)
        {
            return await new PatientService().Get(id);
        }

        [HttpPost]
        public async Task<PatientDto> Post([FromBody] PatientDto dto)
        {
            return await new PatientService().Post(dto);
        }
    }
}