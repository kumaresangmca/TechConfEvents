using Microsoft.AspNetCore.Mvc;
using TechConf.Models.DTO;
using TechConf.Services.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechConf.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationService<OrganizationDTO> service;
        public OrganizationsController(IOrganizationService<OrganizationDTO> service)
        {
            this.service = service;
        }
        // GET: api/Organization
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDTO<List<OrganizationDTO>>))]
        public async Task<ActionResult> Get()
        {
            var resultDTO = new ResultDTO<List<OrganizationDTO>>();
            var data = await service.GetAllAsync(1, 100);
            resultDTO.Results = data;
            return Ok(resultDTO);
        }

        // GET api/Organization/1
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDTO<OrganizationDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetById(int id)
        {
            var resultDTO = new ResultDTO<OrganizationDTO>();
            var data = await service.GetByIdAsync(id);
            if (data == null)
            {
                resultDTO.ErrorsMessages = new List<string>() { $"Organization not found with id : {id}" };
            }
            else
            {
                resultDTO.Results = data;
            }
            return Ok(resultDTO);
        }

        // GET api/Organization/VIR
        [HttpGet("{code:alpha}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDTO<OrganizationDTO?>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetByCode(string code)
        {
            var resultDTO = new ResultDTO<OrganizationDTO>();
            var data = await service.GetByCodeAsync(code);
            if (data == null)
            {
                resultDTO.ErrorsMessages = new List<string>() { $"Organization not found with code : {code}" };
                           }
            else
            {
                resultDTO.Results = data;
            }
            return Ok(resultDTO);
        }

        //// POST api/Organization
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResultDTO<OrganizationDTO>))]
        //public async Task<ActionResult> Post([FromBody] OrganizationDTO model)
        //{
        //    var resultDTO = new ResultDTO<OrganizationDTO>();
        //    return Ok(resultDTO);

        //}

        //// DELETE api/Organization/1
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
