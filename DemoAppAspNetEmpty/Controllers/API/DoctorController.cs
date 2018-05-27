using DemoAppAspNetEmpty.Dtos;
using DemoAppAspNetEmpty.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace DemoAppAspNetEmpty.Controllers.API
{
    [RoutePrefix("api/doctor")]
    public class DoctorController : ApiController
    {
        [HttpGet]
        [Route("GetAll")]
        public async Task<List<DoctorDto>> GetAll()
        {
            return await new DoctorService().GetAll();
        }

        [HttpGet]
        [Route("Get")]
        public async Task<DoctorDto> Get(int id)
        {
            return await new DoctorService().Get(id);
        }

        [HttpPost]
        public async Task<DoctorDto> Post([FromBody] DoctorDto dto)
        {
            return await new DoctorService().Post(dto);
        }
    }
}